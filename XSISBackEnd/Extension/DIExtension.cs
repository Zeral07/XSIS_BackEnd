using XSISDataAccess.Interface;
using XSISDataAccess.Models;
using XSISDataAccess.Repository;
using XSISFacade.Facade;
using XSISFacade.Interface;

namespace XSISBackEnd.Extension
{
    public static class DIExtension
    {
        public static IServiceCollection AddDIGroup(
            this IServiceCollection services)
        {
            services.AddSingleton<DataContext>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieFacade, MovieFacade>();

            return services;
        }
    }
}
