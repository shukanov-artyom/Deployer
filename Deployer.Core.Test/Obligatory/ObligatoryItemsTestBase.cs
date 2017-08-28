using System;
using Deployer.Core.ObligatoryDeployment;
using Microsoft.Extensions.Configuration;

namespace Deployer.Core.Test.Obligatory
{
    public abstract class ObligatoryItemsTestBase
    {
        private const string json = "obligatoryDeployments.json";

        protected IConfigurationSection GetSection(string sectionName)
        {
            return GetConfigurationPrivate().GetSection(sectionName);
        }

        protected TType GetTyped<TType>(string sectionName) where TType : class
        {
            var section = GetSection(sectionName);
            return section.Get<TType>();
        }

        protected ObligatoryDeploymentsConfiguration GetConfiguration()
        {
            return new ObligatoryDeploymentsConfiguration(GetConfigurationPrivate());
        }

        private IConfiguration GetConfigurationPrivate()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(json);
            return builder.Build();
        }
    }
}
