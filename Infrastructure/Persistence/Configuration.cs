using Microsoft.Extensions.Configuration;

namespace Persistence
{
    static class Configuration
    {
        static public string ConnectionStringSqlServer
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/WebApi/"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager["ConnectionStrings:SqlServerConnection"];
            }
        }

    }
}
