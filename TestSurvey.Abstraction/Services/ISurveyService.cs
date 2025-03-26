using TestSurvey.Abstractions.Models;

namespace TestSurvey.Abstractions.Services
{
    public interface ISurveyService
    {
        void SaveSurvey(Survey survey);
    }
}
