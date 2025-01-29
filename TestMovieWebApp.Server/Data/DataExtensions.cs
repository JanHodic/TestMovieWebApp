﻿using TestMovieWebApp.Server.Commons.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace TestMovieWebApp.Server.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ILogger, Logger<UserDateIdentity>>();
            var connectionString = configuration.GetConnectionString("TestWebAppDb");

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException($"{nameof(connectionString)} not configured.");
            services.AddDbContext<TestWebAppDbContext>(options =>
                options.UseSqlServer(connectionString).UseTriggers(triggerOptions =>
                            triggerOptions
                                .AddTrigger<UserDateIdentity>().MaxCascadeCycles(2)
                    //.AddTrigger<HistoryTrigger>()
                    )
                    .UseLazyLoadingProxies()
                    .ConfigureWarnings(
                        x => x.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning)
                    ));
            //registering of repositories
            return services;
        }
    }
}
