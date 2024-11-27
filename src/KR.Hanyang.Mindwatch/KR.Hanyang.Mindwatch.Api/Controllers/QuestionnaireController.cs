using Microsoft.AspNetCore.Mvc;
using KR.Hanyang.Mindwatch.Domain.Entities;
using KR.Hanyang.Mindwatch.Domain.Interfaces;

namespace KR.Hanyang.Mindwatch.Api.Controllers
{
    [ApiController]
    [Route("api/questionnaires")]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IMindwatchRepository _repository;
        private readonly ILogger<QuestionnaireController> _logger;

        public QuestionnaireController(ILogger<QuestionnaireController> logger, IMindwatchRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
    }
}