using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.BLL.Interfaces;
using msac_competition.BLL.Services;
using msac_competition.DAL.EF;
using msac_competition.DAL.Interfaces;
using msac_competition.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace msac_competition.BLL.Infrastructure
{
    public static class MyServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlContextDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options =>options.UseLazyLoadingProxies().UseSqlServer(connectionString).EnableSensitiveDataLogging()
                .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning)));
            return services;
        }

        public static IServiceCollection AddUnitOfWorkDependencies(this IServiceCollection services)
        {
            //services.AddScoped<IRepository, GenericRepository>().AddDbContext<ApplicationContext>();
            services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>)).AddDbContext<ApplicationContext>();

            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ICoachService, CoachService>();
            //services.AddScoped<ICompetitionService, CompetitionService>();
            //services.AddScoped<IFstService, FstService>();
            //services.AddScoped<ISportmanService, SportmanService>();
            //services.AddScoped<ICityService, CityService>();
            return services;
        }
    }
}
