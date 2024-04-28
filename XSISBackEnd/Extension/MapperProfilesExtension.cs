﻿using XSISFacade.AutoMapper;

namespace XSISBackEnd.Extension
{
    public static class MapperProfilesExtension
    {
        public static IServiceCollection AddMapperProfiles(
            this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(MovieProfile)
            );

            return services;
        }
    }
}
