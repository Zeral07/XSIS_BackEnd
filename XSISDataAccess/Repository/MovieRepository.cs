using Dapper;
using Microsoft.EntityFrameworkCore;
using XSISDataAccess.Interface;
using XSISDataAccess.Models;
using XSISDataAccess.Utils;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace XSISDataAccess.Repository
{
    public class MovieRepository(DataContext context) : IMovieRepository
    {
        private readonly DataContext _context = context;

        public async Task<Movie> Create(Movie entity)
        {
            using (var con = _context.CreateConnection())
            {
                var columns = CommonHelper.GetColumns<Movie>().Where(w => !w.ToLower().Contains("id")).ToList();
                var stringOfColumns = string.Join(", ", columns);
                var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
                string query = $"INSERT INTO {typeof(Movie).Name} ({stringOfColumns}) VALUES ({stringOfParameters}) RETURNING Id";
                entity.Id = 0;
                entity.Id = await con.ExecuteScalarAsync<int>(query, entity);
                return entity;
            }
        }

        public async Task Delete(int id)
        {
            using (var con = _context.CreateConnection())
            {
                string query = $"DELETE FROM {typeof(Movie).Name} WHERE id = @Id";
                await con.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<List<Movie>> GetAll()
        {
            using (var con = _context.CreateConnection())
            {
                string query = $"SELECT * FROM {typeof(Movie).Name}";
                return (List<Movie>)await con.QueryAsync<Movie>(query);
            }
        }

        public async Task<Movie?> GetByID(int id)
        {
            using (var con = _context.CreateConnection())
            {
                string query = $"SELECT * FROM {typeof(Movie).Name} WHERE id = @Id";
                return await con.QuerySingleOrDefaultAsync<Movie?>(query, new { Id = id });
            }
        }

        public async Task<Movie> Update(Movie entity)
        {
            using (var con = _context.CreateConnection())
            {
                var stringOfColumns = string.Join(", ", CommonHelper.GetColumns<Movie>().Where(w => !w.ToLower().Contains("id")).Select(e => $"{e} = @{e}"));
                string query = $"UPDATE {typeof(Movie).Name} SET {stringOfColumns} WHERE {stringOfColumns.Split(',')[0]}";
                await con.ExecuteAsync(query, entity);
                return entity;
            }
        }
    }
}
