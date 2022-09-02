using GraduationProject.ApplicationLogic.Models;
using GraduationProject.ApplicationLogic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.Events
{
    public class IndexModel : PageModel
    {
        private EventService eventService;
        private AttendeeService attendeeService;
        private readonly UserManager<IdentityUser> userManager;
        public IList<Event> Events { get; set; }
        public IndexModel(EventService eventService, AttendeeService attendeeService, UserManager<IdentityUser> userManager)
        {
            this.eventService = eventService;
            this.attendeeService = attendeeService;
            this.userManager = userManager;
            Events = new List<Event>();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var attendees = attendeeService.GetEventsForUser(user.Id);
            PopulateEvents(attendees);
            return Page();
        }

        private void PopulateEvents(IEnumerable<Attendee> attendees)
        {
            foreach(var item in attendees)
            {
                var eventt = eventService.Get(item.EventId.ToString());
                if(eventt is not null)
                    Events.Add(eventt);
            }
        }
    }
}
