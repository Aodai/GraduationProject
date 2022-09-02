using GraduationProject.ApplicationLogic.Models;
using GraduationProject.ApplicationLogic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.Events
{
    public class ManageModel : PageModel
    {
        private EventService eventService; 
        private UserManager<IdentityUser> userManager;
        public  IList<Event> Events { get; set; }

        public ManageModel(EventService eventService, UserManager<IdentityUser> userManager)
        {
            this.eventService = eventService;
            this.userManager = userManager;
            Events = new List<Event>();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            Guid.TryParse(user.Id, out var userId);
            Events = eventService.GetEvents().Where(e => e.OrganiserId == userId).ToList();
            return Page();
        }
    }
}
