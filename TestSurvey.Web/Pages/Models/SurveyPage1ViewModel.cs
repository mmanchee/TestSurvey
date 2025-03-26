using System;
using System.ComponentModel.DataAnnotations;

namespace TestSurvey.Presentation.Models
{
    public class SurveyPage1ViewModel
    {
        [Required(ErrorMessage = "Please select today's date.")]
        [DataType(DataType.Date)]
        public DateTime? DateOfSurvey { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }
    }
}
