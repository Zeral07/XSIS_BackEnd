using XSISFacade.Facade;
using XSISFacade.Interface;

namespace XSISBackEnd.Extension
{
    public static class DIExtension
    {
        public static IServiceCollection AddDIGroup(
            this IServiceCollection services)
        {
            services.AddScoped<IMovieFacade, MovieFacade>();

            return services;
        }
    }
}
