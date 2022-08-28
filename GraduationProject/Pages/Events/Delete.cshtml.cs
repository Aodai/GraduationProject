using GraduationProject.ApplicationLogic.Models;
using GraduationProject.ApplicationLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationProject.Pages.Events
{
    public class DeleteModel : PageModel
    {
        private EventService eventService;

        [BindProperty]
        public Event Evnt { get; set; }

        public DeleteModel(EventService eventService)
        {
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

        public IActionResult OnPost(string id)
        {
            if (id == null)
                return NotFound();

            var eventt = eventService.Get(id);
            if(eventt == null)
            {
                return NotFound();
            }

            eventService.Delete(eventt);
            return RedirectToPage("./Manage");
        }
    }
}
