using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestSurvey.Presentation.Models;
using System.Text.Json;

namespace TestSurvey.Presentation.Pages
{
    public class Page1Model : PageModel
    {
        [BindProperty]
        public SurveyPage1ViewModel SurveyPage1 { get; set; }

        public void OnGet()
        {
            // Repopulate Page1 data if available from session.
            var page1Json = HttpContext.Session.GetString("SurveyPage1");
            if (!string.IsNullOrEmpty(page1Json))
            {
                SurveyPage1 = JsonSerializer.Deserialize<SurveyPage1ViewModel>(page1Json);
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save Page1 data in session.
            HttpContext.Session.SetString("SurveyPage1", JsonSerializer.Serialize(SurveyPage1));
            return RedirectToPage("Page2");
        }
    }
}
