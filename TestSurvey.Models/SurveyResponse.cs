namespace TestSurvey.Models
{
    public class SurveyResponse
    {
        public DateOnly? SurveyDate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Rating { get; set; }
        public string? Feedback { get; set; }

        public override string ToString()
        {
            return $"Date: {SurveyDate?.ToShortDateString()}, Name: {FirstName} {LastName}, Rating: {Rating}, Feedback: {Feedback}";
        }
    }
}