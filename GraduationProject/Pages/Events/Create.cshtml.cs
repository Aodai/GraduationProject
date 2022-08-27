using GraduationProject.ApplicationLogic.Models;
using GraduationProject.ApplicationLogic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private EventService eventService;

        public CreateModel(UserManager<IdentityUser> userManager, EventService eventService)
        {
            this.userManager = userManager;
            this.eventService = eventService;
        }
        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            var user = await userManager.GetUserAsync(HttpContext.User);
            Guid.TryParse(user.Id, out var userId);
            if(ModelState.IsValid)
            {
                var evnt = new Event();
                evnt.Id = Guid.NewGuid();
                evnt.Name = Input.Name;
                evnt.Description = Input.Description;
                evnt.Image = Input.Image;
                evnt.StartDate = Input.StartDate;
                evnt.EndDate = Input.EndDate;
                evnt.OrganiserId = userId;

                eventService.Add(evnt);
                return LocalRedirect(returnUrl);
            }
            return Page();
        }

        public string? ReturnUrl { get; set; }
        [BindProperty]
        public InputModel? Input { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(60, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [Display(Name = "Event name")]
            public string? Name { get; set; }

            [Required]
            [Display(Name = "Description")]
            public string? Description { get; set; }

            [Required]
            [Display(Name = "Picture URL")]
            public string? Image { get; set; }

            [Required]
            [Display(Name = "Start date")]
            public DateTime StartDate { get; set; }
            [Required]
            [Display(Name = "End date")]
            public DateTime EndDate { get; set; }
        }
    }
}
