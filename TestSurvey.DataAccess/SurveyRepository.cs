using System.Collections.Generic;
using System.Linq;
using TestSurvey.Abstractions.Models;
using TestSurvey.Abstractions.Data;

namespace TestSurvey.DataAccess
{
    public class SurveyRepository : ISurveyRepository
    {
        private static List<Survey> _surveys = new List<Survey>();
        private static int _currentId = 1;

        public void AddSurvey(Survey survey)
        {
            survey.SurveyId = _currentId++;
            _surveys.Add(survey);
        }

        public Survey GetSurvey(int surveyId)
        {
            return _surveys.FirstOrDefault(s => s.SurveyId == surveyId);
        }
    }
}
