using TestSurvey.Abstractions.Models;
using TestSurvey.Abstractions.Services;
using TestSurvey.Abstractions.Data;

namespace TestSurvey.BusinessLogic
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _repository;

        public SurveyService(ISurveyRepository repository)
        {
            _repository = repository;
        }

        public void SaveSurvey(Survey survey)
        {
            // Additional business validations can be added here if needed.
            _repository.AddSurvey(survey);
        }
    }
}
