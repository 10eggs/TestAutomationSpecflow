using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalEngland.Specs.Helpers
{
    public class ConfigBuild
    {
        public IConfigurationRoot configuration;
        public ConfigBuild()
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("./Helpers/specflow.json");
            configuration = config.Build();
        }
    }
}
