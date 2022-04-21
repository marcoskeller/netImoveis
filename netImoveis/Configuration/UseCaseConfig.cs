using Microsoft.Extensions.DependencyInjection;
using netImoveis.Models;

namespace netImoveis.Configuration
{
    public static class UseCaseConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IImoveisUseCase, ImoveisUseCase>();
        }
    }
}
