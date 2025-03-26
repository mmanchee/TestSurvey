using System;
using System.ComponentModel.DataAnnotations;

namespace TestSurvey.Abstractions.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }

        [Required(ErrorMessage = "Please select today's date.")]
        [DataType(DataType.Date)]
        public DateTime? DateOfSurvey { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Range(1, 5, ErrorMessage = "Please rate between 1 and 5.")]
        public int Rating { get; set; } = 3;

        public string Feedback { get; set; }

        public string FavoriteColor { get; set; }

        public string Why { get; set; }

        public string Weather { get; set; }

        public List<string> Feeling { get; set; }
    }
}

