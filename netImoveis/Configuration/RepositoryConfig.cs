using Microsoft.Extensions.DependencyInjection;
using netImoveis.Data.Repository;
using netImoveis.Models;
using netImoveis.Shared;
using System;

namespace netImoveis.Configuration
{
    public static class RepositoryConfig
    {
        public static void ConfigureServices(IServiceCollection services, ApplicationConfig applicationConfig)
        {
            services.AddScoped<IImoveisRepository, ImoveisRepository>();

            services.AddHttpClient<IImoveisRepository, ImoveisRepository>(client =>
            {
                client.BaseAddress = new Uri(applicationConfig.ImoveisBase.BaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        }
    }
}
