using System;
using System.Collections.Generic;
using Deployer.Core.PathConversion;
using Xunit;

namespace Deployer.Core.Test.PathConversion
{
    public class PathConverterTest
    {
        [Fact]
        public void Test()
        {
            var converters = new List<IPathConversion>()
            {
                new ToWebsiteSubfolderConversion(),
                new ToUnixPathConversion()
            };
            var converter = new PathConverter(converters);
            string path =
                @"website\App_Code\Enums\Cases\CasesSteps.cs";
            string result = converter.Convert(path);
        }
    }
}
