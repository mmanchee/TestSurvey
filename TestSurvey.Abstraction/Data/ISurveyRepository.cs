using TestSurvey.Abstractions.Models;

namespace TestSurvey.Abstractions.Data
{
    public interface ISurveyRepository
    {
        void AddSurvey(Survey survey);
        Survey GetSurvey(int surveyId);
    }
}
