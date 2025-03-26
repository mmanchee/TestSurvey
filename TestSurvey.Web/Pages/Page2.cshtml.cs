using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestSurvey.Presentation.Models;
using System.Text.Json;

namespace TestSurvey.Presentation.Pages
{
    public class Page2Model : PageModel
    {
        [BindProperty]
        public SurveyPage2ViewModel SurveyPage2 { get; set; }

        // This property holds Page1 data, loaded from session.
        public SurveyPage1ViewModel SurveyPage1 { get; set; }

        public IActionResult OnGet()
        {
            // Retrieve Page1 data from session.
            var page1Json = HttpContext.Session.GetString("SurveyPage1");
            if (string.IsNullOrEmpty(page1Json))
            {
                return RedirectToPage("Page1");
            }
            SurveyPage1 = JsonSerializer.Deserialize<SurveyPage1ViewModel>(page1Json);

            // Retrieve Page2 data from session (if available) so that the fields remain persistent.
            var page2Json = HttpContext.Session.GetString("SurveyPage2");
            if (!string.IsNullOrEmpty(page2Json))
            {
                SurveyPage2 = JsonSerializer.Deserialize<SurveyPage2ViewModel>(page2Json);
            }
            else
            {
                // Initialize as a new instance if no previous data exists.
                SurveyPage2 = new SurveyPage2ViewModel();
            }

            return Page();
        }

        // Handler for the Back button: Return to Page1.
        public IActionResult OnPostBack()
        {
            return RedirectToPage("Page1");
        }

        // Handler for the Next button: Validate and save Page2 data to session, then navigate to Page3.
        public IActionResult OnPostNext()
        {
            if (!ModelState.IsValid)
            {
                // Repopulate Page1 data (and Page2 if any exists) for rendering.
                var page1Json = HttpContext.Session.GetString("SurveyPage1");
                if (!string.IsNullOrEmpty(page1Json))
                {
                    SurveyPage1 = JsonSerializer.Deserialize<SurveyPage1ViewModel>(page1Json);
                }
                return Page();
            }

            // Save Page2 data in session.
            HttpContext.Session.SetString("SurveyPage2", JsonSerializer.Serialize(SurveyPage2));
            return RedirectToPage("Page3");
        }
    }
}
