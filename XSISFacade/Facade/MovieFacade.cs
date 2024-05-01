using AutoMapper;
using XSISDataAccess.Interface;
using XSISDataAccess.Models;
using XSISDataAccess.ViewModel;
using XSISFacade.Interface;

namespace XSISFacade.Facade
{
    public class MovieFacade(IMovieRepository repo, IMapper mapper) : IMovieFacade
    {
        private readonly IMovieRepository _repo = repo;
        private readonly IMapper _mapper = mapper;

        public async Task<ResultResponse<MovieDto>> Create(MovieDto modelDto)
        {
            var resultResponse = new ResultResponse<MovieDto>();
            try
            {
                Movie entity = _mapper.Map<Movie>(modelDto);
                entity = await _repo.Create(entity);
                resultResponse.Total = 1;
                resultResponse.Result = _mapper.Map<MovieDto>(entity);
                resultResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                resultResponse.IsSuccess = false;
                resultResponse.Errors.Add(new ErrorMessage { ErrorCode = "1", Message = "Something when wrong.", TechnicalMessage = ex.Message });
            }
            return resultResponse;
        }

        public async Task<ResultResponse<MovieDto>> Delete(int id)
        {
            var resultResponse = new ResultResponse<MovieDto>();
            try
            {
                Movie? obj = await _repo.GetByID(id);
                if (obj is null)
                {
                    resultResponse.Errors.Add(new ErrorMessage { ErrorCode = "2", Message = "Data tidak ditemukan.", TechnicalMessage = "" });
                    resultResponse.IsSuccess = false;
                }
                else
                {
                    await _repo.Delete(id);
                    resultResponse.IsSuccess = true;
                }
                resultResponse.Total = obj is null ? 0 : 1;
                resultResponse.Result = null;
            }
            catch (Exception ex)
            {
                resultResponse.IsSuccess = false;
                resultResponse.Errors.Add(new ErrorMessage { ErrorCode = "1", Message = "Something when wrong.", TechnicalMessage = ex.Message });
            }
            return resultResponse;
        }

        public async Task<ResultResponse<MovieDto>> Retrieve(int id)
        {
            var resultResponse = new ResultResponse<MovieDto>();
            try
            {
                Movie? obj = await _repo.GetByID(id);
                if (obj is null)
                {
                    resultResponse.Errors.Add(new ErrorMessage { ErrorCode = "2", Message = "Data tidak ditemukan.", TechnicalMessage = "" });
                    resultResponse.IsSuccess = false;
                }
                else
                {
                    resultResponse.Result = _mapper.Map<MovieDto>(obj);
                    resultResponse.IsSuccess = true;
                }

                resultResponse.Total = obj is null ? 0 : 1;
            }
            catch (Exception ex)
            {
                resultResponse.IsSuccess = false;
                resultResponse.Errors.Add(new ErrorMessage { ErrorCode = "1", Message = "Something when wrong.", TechnicalMessage = ex.Message });
            }
            return resultResponse;
        }

        public async Task<ResultResponse<List<MovieDto>>> RetrieveList()
        {
            var resultResponse = new ResultResponse<List<MovieDto>>();
            try
            {
                List<MovieDto> result = _mapper.Map<List<MovieDto>>(await _repo.GetAll());
                if (!result.Any())
                {
                    resultResponse.Errors.Add(new ErrorMessage { ErrorCode = "2", Message = "Data tidak ditemukan.", TechnicalMessage = "" });
                    resultResponse.IsSuccess = false;
                }
                else
                {
                    resultResponse.Total = result.Count;
                    resultResponse.Result = result;
                    resultResponse.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                resultResponse.IsSuccess = false;
                resultResponse.Errors.Add(new ErrorMessage { ErrorCode = "1", Message = "Something when wrong.", TechnicalMessage = ex.Message });
            }
            return resultResponse;
        }

        public async Task<ResultResponse<MovieDto>> Update(MovieDto modelDto)
        {
            var resultResponse = new ResultResponse<MovieDto>();
            try
            {
                Movie? obj = await _repo.GetByID(modelDto.Id);
                if (obj is null)
                {
                    resultResponse.Errors.Add(new ErrorMessage { ErrorCode = "2", Message = "Data tidak ditemukan.", TechnicalMessage = "" });
                    resultResponse.IsSuccess = false;
                }
                else
                {
                    await _repo.Update(obj);
                    resultResponse.IsSuccess = true;
                }
                resultResponse.Total = obj is null ? 0 : 1;
                resultResponse.Result = obj is null ? _mapper.Map<MovieDto>(obj) : new();
            }
            catch (Exception ex)
            {
                resultResponse.IsSuccess = false;
                resultResponse.Errors.Add(new ErrorMessage { ErrorCode = "1", Message = "Something when wrong.", TechnicalMessage = ex.Message });
            }
            return resultResponse;
        }
    }
}
