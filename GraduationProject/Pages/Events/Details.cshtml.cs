using GraduationProject.ApplicationLogic.Models;
using GraduationProject.ApplicationLogic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private EventService eventService;
        private AttendeeService attendeeService;

        [BindProperty]
        public IList<IdentityUser> AttendeeList { get; set; }
        [BindProperty]
        public Event Evnt { get; set; }

        public DetailsModel(UserManager<IdentityUser> userManager, EventService eventService, AttendeeService attendeeService)
        {
            this.userManager = userManager;
            this.eventService = eventService;
            this.attendeeService = attendeeService;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
                return NotFound();

            Evnt = eventService.Get(id);
            if (Evnt == null)
                return NotFound();
            await GetAttendeesAsync(Evnt.Id.ToString());

            return Page();
        }

        // TODO: Maybe change attendance list layout.
        public async Task<IActionResult> OnPostAsync(string id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            Guid.TryParse(user.Id, out var userId);
            if (attendeeService.AlreadyInterested(user.Id, Evnt.Id.ToString()))
                return RedirectToPage("Details", new {EventId = Evnt.Id});

            var attnd = new Attendee();
            attnd.Id = Guid.NewGuid();
            attnd.EventId = Evnt.Id;
            attnd.AttendeeId = userId;
            attendeeService.Add(attnd);
            return RedirectToPage("Details", new { EventId = Evnt.Id });
        }

        private async Task GetAttendeesAsync(string eventId)
        {
            AttendeeList = new List<IdentityUser>();
            var attendees = attendeeService.GetAttendeesForEvent(eventId);
            foreach (var attendee in attendees)
            {
                var user = await userManager.FindByIdAsync(attendee.AttendeeId.ToString());
                AttendeeList.Add(user);
            }
        }
    }
}
