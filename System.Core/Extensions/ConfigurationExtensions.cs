using Microsoft.Extensions.Configuration;

namespace System.Core.Extensions
{
    public static class ConfigurationRootExtensions
    {
        public static IConfigurationSection TryGetSection(this IConfiguration configuration, string section)
        {            
            var configurationSection = configuration.GetSection(section);            
            if (configurationSection == null)
                throw new Exception($"invalid {section} section");            
            return configurationSection;
        }
    }
}