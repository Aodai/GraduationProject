using GraduationProject.ApplicationLogic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.Events
{
    public class IndexModel : PageModel
    {
        private EventService eventService;
        private readonly UserManager<IdentityUser> userManager;
        public IndexModel(EventService eventService, UserManager<IdentityUser> userManager)
        {
            this.eventService = eventService;
            this.userManager = userManager;
        }

        public void OnGet()
        {
        }
    }
}
