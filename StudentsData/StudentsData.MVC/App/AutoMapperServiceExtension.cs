using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using StudentsData.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsData.MVC.App
{
    public static class AutoMapperServiceExtension
    {
        public static void AddStudentsDataAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Converter());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
