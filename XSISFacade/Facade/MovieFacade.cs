using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XSISDataAccess.Models;
using XSISDataAccess.ViewModel;
using XSISFacade.Interface;

namespace XSISFacade.Facade
{
    public class MovieFacade(XsisbackEndContext context, IMapper mapper) : IMovieFacade
    {
        private readonly XsisbackEndContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<ResultResponse<MovieDto>> Create(MovieDto modelDto)
        {
            var resultResponse = new ResultResponse<MovieDto>();
            try
            {
                Movie obj = _mapper.Map<Movie>(modelDto);
                await _context.Movies.AddAsync(obj);
                await _context.SaveChangesAsync();
                resultResponse.Total = 1;
                resultResponse.Result = _mapper.Map<MovieDto>(obj);
                resultResponse.IsSuccess = false;
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
                Movie? obj = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);
                if (obj is null) {
                    resultResponse.Errors.Add(new ErrorMessage { ErrorCode = "2", Message = "Data tidak ditemukan.", TechnicalMessage = "" });
                    resultResponse.IsSuccess = false;
                }
                else 
                {
                    _context.Movies.Remove(obj);
                    await _context.SaveChangesAsync();
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

        public async Task<ResultResponse<MovieDto>> Retrieve(int id)
        {
            var resultResponse = new ResultResponse<MovieDto>();
            try
            {
                MovieDto result = _mapper.Map<MovieDto>(await _context.Movies.SingleOrDefaultAsync(x => x.Id == id));
                resultResponse.Total = result is null ? 0 : 1;
                resultResponse.Result = result;
                resultResponse.IsSuccess = true;
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
                List<MovieDto> result = _mapper.Map<List<MovieDto>>(await _context.Movies.ToListAsync());
                resultResponse.Total = result.Count;
                resultResponse.Result = result;
                resultResponse.IsSuccess = true;
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
                Movie? obj = await _context.Movies.SingleOrDefaultAsync(x => x.Id == modelDto.Id);
                if (obj is null)
                {
                    resultResponse.Errors.Add(new ErrorMessage { ErrorCode = "2", Message = "Data tidak ditemukan.", TechnicalMessage = "" });
                    resultResponse.IsSuccess = false;
                }
                else
                {
                    _context.Movies.Update(obj);
                    await _context.SaveChangesAsync();
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
