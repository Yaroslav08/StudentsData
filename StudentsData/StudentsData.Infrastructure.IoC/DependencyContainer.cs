using Microsoft.Extensions.DependencyInjection;
using StudentsData.Application.Interfaces;
using StudentsData.Application.Services;
using StudentsData.Domain.Interfaces;
using StudentsData.Infrastructure.Data;
using StudentsData.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
namespace StudentsData.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterMVCServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupService, GroupService>();

            
        }
    }
}