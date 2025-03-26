using System.ComponentModel.DataAnnotations;

namespace TestSurvey.Presentation.Models
{
    public class SurveyPage3ViewModel
    {
        [Required(ErrorMessage = "Please select your favorite color.")]
        public string FavoriteColor { get; set; }

        [Required(ErrorMessage = "Please explain your choice.")]
        public string Why { get; set; }
    }
}
