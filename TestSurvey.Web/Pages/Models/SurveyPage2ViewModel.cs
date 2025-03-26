using System.ComponentModel.DataAnnotations;

namespace TestSurvey.Presentation.Models
{
    public class SurveyPage2ViewModel
    {
        [Range(1, 5, ErrorMessage = "Please rate between 1 and 5.")]
        public int Rating { get; set; } = 3;

        [Required(ErrorMessage = "Feedback is required.")]
        public string Feedback { get; set; }
    }
}
