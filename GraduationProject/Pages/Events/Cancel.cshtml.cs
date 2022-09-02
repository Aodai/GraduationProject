using GraduationProject.ApplicationLogic.Models;
using GraduationProject.ApplicationLogic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.Events
{
    public class CancelModel : PageModel
    {
        private EventService eventService;
        private AttendeeService attendeeService;
        private UserManager<IdentityUser> userManager;

        [BindProperty]
        public Event Evnt { get; set; }

        public CancelModel(EventService eventService, AttendeeService attendeeService, UserManager<IdentityUser> userManager)
        {
            this.eventService = eventService;
            this.attendeeService = attendeeService;
            this.userManager = userManager;
        }
        public IActionResult OnGet(string id)
        {
            if (id == null)
                return NotFound();

            Evnt = eventService.Get(id);
            if (Evnt == null)
                return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
                return NotFound();

            var eventt = eventService.Get(id);
            if (eventt == null)
            {
                return NotFound();
            }

            var user = await userManager.GetUserAsync(HttpContext.User);
            Guid.TryParse(user.Id, out var userId);

            var attendee = attendeeService.GetAttendees().Where(attnd => attnd.EventId == Evnt.Id && attnd.AttendeeId == userId).FirstOrDefault();
            attendeeService.Delete(attendee);
            return RedirectToPage("./Index");
        }
    }
}
