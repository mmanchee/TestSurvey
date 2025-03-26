using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSurvey.Presentation.Models
{
    public class SurveyPage4ViewModel
    {
        [Required(ErrorMessage = "Please select the weather.")]
        public string Weather { get; set; }

        [Required(ErrorMessage = "Please select at least one feeling.")]
        [MinLength(1, ErrorMessage = "Please select at least one feeling.")]
        public List<string> Feeling { get; set; } = new List<string>();
    }
}
