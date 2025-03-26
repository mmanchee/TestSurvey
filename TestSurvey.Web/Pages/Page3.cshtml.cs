using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using TestSurvey.Presentation.Models;

namespace TestSurvey.Presentation.Pages
{
    public class Page3Model : PageModel
    {
        [BindProperty]
        public SurveyPage3ViewModel SurveyPage3 { get; set; }

        // Retrieve previous pages’ data for persistence.
        public SurveyPage1ViewModel SurveyPage1 { get; set; }
        public SurveyPage2ViewModel SurveyPage2 { get; set; }

        public IActionResult OnGet()
        {
            // Retrieve Page1 data from session.
            var page1Json = HttpContext.Session.GetString("SurveyPage1");
            if (string.IsNullOrEmpty(page1Json))
            {
                return RedirectToPage("Page1");
            }
            SurveyPage1 = JsonSerializer.Deserialize<SurveyPage1ViewModel>(page1Json);

            // Retrieve Page2 data from session.
            var page2Json = HttpContext.Session.GetString("SurveyPage2");
            if (string.IsNullOrEmpty(page2Json))
            {
                return RedirectToPage("Page2");
            }
            SurveyPage2 = JsonSerializer.Deserialize<SurveyPage2ViewModel>(page2Json);

            // Retrieve Page3 data for persistence.
            var page3Json = HttpContext.Session.GetString("SurveyPage3");
            if (!string.IsNullOrEmpty(page3Json))
            {
                SurveyPage3 = JsonSerializer.Deserialize<SurveyPage3ViewModel>(page3Json);
            }
            else
            {
                SurveyPage3 = new SurveyPage3ViewModel();
            }

            return Page();
        }

        // Handler for the Back button: Go back to Page2.
        public IActionResult OnPostBack()
        {
            return RedirectToPage("Page2");
        }

        // Handler for Next: Validate and save Page3 data to session, then navigate to Page4.
        public IActionResult OnPostNext()
        {
            if (!ModelState.IsValid)
            {
                // Repopulate the session data for the view.
                var page1Json = HttpContext.Session.GetString("SurveyPage1");
                if (!string.IsNullOrEmpty(page1Json))
                {
                    SurveyPage1 = JsonSerializer.Deserialize<SurveyPage1ViewModel>(page1Json);
                }
                var page2Json = HttpContext.Session.GetString("SurveyPage2");
                if (!string.IsNullOrEmpty(page2Json))
                {
                    SurveyPage2 = JsonSerializer.Deserialize<SurveyPage2ViewModel>(page2Json);
                }
                return Page();
            }

            // Save Page3 data
            HttpContext.Session.SetString("SurveyPage3", JsonSerializer.Serialize(SurveyPage3));

            return RedirectToPage("Page4");
        }
    }
}
