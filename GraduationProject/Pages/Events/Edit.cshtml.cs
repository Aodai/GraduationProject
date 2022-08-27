using GraduationProject.ApplicationLogic.Models;
using GraduationProject.ApplicationLogic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.Events
{
    public class EditModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private EventService eventService;

        [BindProperty(SupportsGet = true)]
        public Event Evnt { get; set; }

        public EditModel(EventService eventService)
        {
            this.eventService = eventService;
        }

        public IActionResult OnGet(string id)
        {
            if(id == null)
                return NotFound();

            Evnt = eventService.Get(id);
            if (Evnt == null)
                return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                eventService.Update(Evnt);
                return RedirectToPage("./Index");
            }
            
            return Page();
        }

    }
}
