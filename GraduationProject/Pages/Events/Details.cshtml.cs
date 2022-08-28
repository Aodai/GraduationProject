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

        [BindProperty(SupportsGet = true)]
        public Event Evnt { get; set; }

        public DetailsModel(UserManager<IdentityUser> userManager, EventService eventService)
        {
            this.userManager = userManager;
            this.eventService = eventService;
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
    }
}
