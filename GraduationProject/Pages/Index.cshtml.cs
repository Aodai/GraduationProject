using GraduationProject.ApplicationLogic.Models;
using GraduationProject.ApplicationLogic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages
{
    public class IndexModel : PageModel
    {
        private EventService eventService;
        private readonly UserManager<IdentityUser> userManager;
        public IList<Event> Events { get; set; }
        public IndexModel(EventService eventService, UserManager<IdentityUser> userManager)
        {
            this.eventService = eventService;
            this.userManager = userManager;
        }

        public IActionResult OnGet()
        {
            Events = eventService.GetEvents().ToList();
            return Page();
        }
    }
}