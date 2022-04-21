using Microsoft.Extensions.Configuration;
using netImoveis.Shared;


namespace netImoveis.Extensions
{
    public static class ConfigurationExtensions
    {
        public static ApplicationConfig LoadConfiguration(this IConfiguration source)
        {

            var applicationConfig = source.Get<ApplicationConfig>();

            applicationConfig.Logging = source.GetValue<string>("Serilog:WriteTo:0:Args:BasicAuthenticationUsername");
            applicationConfig.Logging = source.GetValue<string>("Serilog:WriteTo:0:Args:BasicAuthenticationPassword");
            applicationConfig.Logging = source.GetValue<string>("Serilog:WriteTo:0:Args:RequestUri");
            applicationConfig.Logging = source.GetValue<string>("Serilog:Properties:Application");
            applicationConfig.Logging = source.GetValue<string>("Serilog:Properties:Environment");

            return applicationConfig;
        }
    }
}
