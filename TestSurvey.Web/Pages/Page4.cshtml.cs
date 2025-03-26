using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using TestSurvey.Presentation.Models;
using TestSurvey.Abstractions.Models;
using TestSurvey.Abstractions.Services;

namespace TestSurvey.Presentation.Pages
{
    public class Page4Model : PageModel
    {
        private readonly ISurveyService _surveyService;

        public Page4Model(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [BindProperty]
        public SurveyPage4ViewModel SurveyPage4 { get; set; }

        // Retrieve data from previous pages.
        public SurveyPage1ViewModel SurveyPage1 { get; set; }
        public SurveyPage2ViewModel SurveyPage2 { get; set; }
        public SurveyPage3ViewModel SurveyPage3 { get; set; }

        public IActionResult OnGet()
        {
            // Retrieve Page1 data.
            var page1Json = HttpContext.Session.GetString("SurveyPage1");
            if (string.IsNullOrEmpty(page1Json))
            {
                return RedirectToPage("Page1");
            }
            SurveyPage1 = JsonSerializer.Deserialize<SurveyPage1ViewModel>(page1Json);

            // Retrieve Page2 data.
            var page2Json = HttpContext.Session.GetString("SurveyPage2");
            if (string.IsNullOrEmpty(page2Json))
            {
                return RedirectToPage("Page2");
            }
            SurveyPage2 = JsonSerializer.Deserialize<SurveyPage2ViewModel>(page2Json);

            // Retrieve Page3 data.
            var page3Json = HttpContext.Session.GetString("SurveyPage3");
            if (string.IsNullOrEmpty(page3Json))
            {
                return RedirectToPage("Page3");
            }
            SurveyPage3 = JsonSerializer.Deserialize<SurveyPage3ViewModel>(page3Json);

            // Retrieve Page4 data if available.
            var page4Json = HttpContext.Session.GetString("SurveyPage4");
            if (!string.IsNullOrEmpty(page4Json))
            {
                SurveyPage4 = JsonSerializer.Deserialize<SurveyPage4ViewModel>(page4Json);
            }
            else
            {
                SurveyPage4 = new SurveyPage4ViewModel();
            }

            return Page();
        }

        // Handler for the Back button: Return to Page3.
        public IActionResult OnPostBack()
        {
            return RedirectToPage("Page3");
        }

        // Handler for Submit: Validate and combine all pages’ data, then process the survey.
        public IActionResult OnPostSubmit()
        {
            if (!ModelState.IsValid)
            {
                // Reload previous pages’ data in case of validation errors.
                var page1Json = HttpContext.Session.GetString("SurveyPage1");
                if (!string.IsNullOrEmpty(page1Json))
                    SurveyPage1 = JsonSerializer.Deserialize<SurveyPage1ViewModel>(page1Json);

                var page2Json = HttpContext.Session.GetString("SurveyPage2");
                if (!string.IsNullOrEmpty(page2Json))
                    SurveyPage2 = JsonSerializer.Deserialize<SurveyPage2ViewModel>(page2Json);

                var page3Json = HttpContext.Session.GetString("SurveyPage3");
                if (!string.IsNullOrEmpty(page3Json))
                    SurveyPage3 = JsonSerializer.Deserialize<SurveyPage3ViewModel>(page3Json);

                return Page();
            }

            // Save Page4 data.
            HttpContext.Session.SetString("SurveyPage4", JsonSerializer.Serialize(SurveyPage4));

            // Retrieve the previously stored data.
            var page1DataJson = HttpContext.Session.GetString("SurveyPage1");
            var page2DataJson = HttpContext.Session.GetString("SurveyPage2");
            var page3DataJson = HttpContext.Session.GetString("SurveyPage3");

            if (string.IsNullOrEmpty(page1DataJson) ||
                string.IsNullOrEmpty(page2DataJson) ||
                string.IsNullOrEmpty(page3DataJson))
            {
                return RedirectToPage("Page1");
            }

            SurveyPage1 = JsonSerializer.Deserialize<SurveyPage1ViewModel>(page1DataJson);
            SurveyPage2 = JsonSerializer.Deserialize<SurveyPage2ViewModel>(page2DataJson);
            SurveyPage3 = JsonSerializer.Deserialize<SurveyPage3ViewModel>(page3DataJson);

            // Combine all data into the complete Survey domain model.
            var survey = new Survey
            {
                DateOfSurvey = SurveyPage1.DateOfSurvey,
                Name = SurveyPage1.Name,
                Rating = SurveyPage2.Rating,
                Feedback = SurveyPage2.Feedback,
                FavoriteColor = SurveyPage3.FavoriteColor,
                Why = SurveyPage3.Why,
                Weather = SurveyPage4.Weather,
                Feeling = SurveyPage4.Feeling  // Ensure that your Survey model supports a List<string> or similar.
            };

            // Save the survey via the business logic layer.
            _surveyService.SaveSurvey(survey);

            // Store the full survey in session for display on the Thank You page.
            HttpContext.Session.SetString("SubmittedSurvey", JsonSerializer.Serialize(survey));

            // Clear temporary session data.
            HttpContext.Session.Remove("SurveyPage1");
            HttpContext.Session.Remove("SurveyPage2");
            HttpContext.Session.Remove("SurveyPage3");
            HttpContext.Session.Remove("SurveyPage4");

            return RedirectToPage("ThankYou");
        }
    }
}
