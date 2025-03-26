using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestSurvey.Abstractions.Models;
using System.Text.Json;

namespace TestSurvey.Presentation.Pages
{
    public class ThankYouModel : PageModel
    {
        public Survey Survey { get; set; }

        public IActionResult OnGet()
        {
            var surveyJson = HttpContext.Session.GetString("SubmittedSurvey");
            if (string.IsNullOrEmpty(surveyJson))
            {
                return RedirectToPage("Index");
            }
            Survey = JsonSerializer.Deserialize<Survey>(surveyJson);
            HttpContext.Session.Remove("SubmittedSurvey");
            return Page();
        }
    }
}

