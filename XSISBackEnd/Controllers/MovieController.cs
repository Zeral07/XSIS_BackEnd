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

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ResultResponse<MovieDto>>> Create([FromBody] MovieDto parameter)
        {
            _logger.LogInformation("Hit API api/movie/create");

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

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<ResultResponse<MovieDto>>> Delete([FromBody] int id)
        {
            _logger.LogInformation("Hit API api/movie/delete/{id}", id);

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
        [Route("Retrieve")]
        public async Task<ActionResult<ResultResponse<MovieDto>>> Retrieve([FromBody] int id)
        {
            _logger.LogInformation("Hit API api/movie/retrieve/{id}", id);

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

        [HttpGet]
        [Route("RetrieveList")]
        public async Task<ActionResult<ResultResponse<List<MovieDto>>>> RetrieveList()
        {
            _logger.LogInformation("Hit API api/movie/retrievelist");

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
        [Route("Update")]
        public async Task<ActionResult<ResultResponse<MovieDto>>> Update([FromBody] MovieDto parameter)
        {
            _logger.LogInformation("Hit API api/movie/update");

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
