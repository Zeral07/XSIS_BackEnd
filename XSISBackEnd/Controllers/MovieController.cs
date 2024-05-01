using Microsoft.AspNetCore.Mvc;
using XSISBackEnd.Interface;
using XSISDataAccess.ViewModel;
using XSISFacade.Interface;

namespace XSISBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController(IMovieFacade movieFacade, ILogger<MovieController> logger) : ControllerBase, IControllerBase<MovieDto>
    {
        private readonly IMovieFacade _movieFacade = movieFacade;
        private readonly ILogger<MovieController> _logger = logger;

        [HttpPost("")]
        public async Task<ActionResult<ResultResponse<MovieDto>>> Create([FromBody] MovieDto parameter)
        {
            _logger.LogInformation("HttpPost API api/movie/create");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _movieFacade.Create(parameter);
            if (result.IsSuccess)
                return Ok(result);
            else
            {
                if (result.Errors.Exists(w => !string.IsNullOrEmpty(w.TechnicalMessage)))
                    _logger.LogError("{error}", string.Join("|", result.Errors.Where(w => !string.IsNullOrEmpty(w.TechnicalMessage)).Select(s => s.TechnicalMessage)));
                return BadRequest(result);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultResponse<MovieDto>>> Delete(int id)
        {
            _logger.LogInformation("HttpDelete API api/movie/{id}", id);

            var result = await _movieFacade.Delete(id);
            if (result.IsSuccess)
                return Ok(result);
            else
            {
                if (result.Errors.Exists(w => !string.IsNullOrEmpty(w.TechnicalMessage)))
                    _logger.LogError("{error}", string.Join("|", result.Errors.Where(w => !string.IsNullOrEmpty(w.TechnicalMessage)).Select(s => s.TechnicalMessage)));
                return BadRequest(result);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultResponse<MovieDto>>> Retrieve(int id)
        {
            _logger.LogInformation("HttpGet API api/movie/{id}", id);

            var result = await _movieFacade.Retrieve(id);
            if (result.IsSuccess)
                return Ok(result);
            else
            {
                if (result.Errors.Exists(w => !string.IsNullOrEmpty(w.TechnicalMessage)))
                    _logger.LogError("{error}", string.Join("|", result.Errors.Where(w => !string.IsNullOrEmpty(w.TechnicalMessage)).Select(s => s.TechnicalMessage)));
                return BadRequest(result);
            }
        }

        [HttpGet("")]
        public async Task<ActionResult<ResultResponse<List<MovieDto>>>> RetrieveList()
        {
            _logger.LogInformation("HttpGet API api/movie");

            var result = await _movieFacade.RetrieveList();
            if (result.IsSuccess)
                return Ok(result);
            else
            {
                if (result.Errors.Exists(w => !string.IsNullOrEmpty(w.TechnicalMessage)))
                    _logger.LogError("{error}", string.Join("|", result.Errors.Where(w => !string.IsNullOrEmpty(w.TechnicalMessage)).Select(s => s.TechnicalMessage)));
                return BadRequest(result);
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ResultResponse<MovieDto>>> Update([FromBody] MovieDto parameter)
        {
            _logger.LogInformation("HttpPatch API api/movie/{id}", parameter.Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _movieFacade.Update(parameter);
            if (result.IsSuccess)
                return Ok(result);
            else
            {
                if (result.Errors.Exists(w => !string.IsNullOrEmpty(w.TechnicalMessage)))
                    _logger.LogError("{error}", string.Join("|", result.Errors.Where(w => !string.IsNullOrEmpty(w.TechnicalMessage)).Select(s => s.TechnicalMessage)));
                return BadRequest(result);
            }
        }
    }
}
