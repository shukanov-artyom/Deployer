using System;
using Deployer.Core.PathConversion;
using Xunit;

namespace Deployer.Core.Test.PathConversion
{
    public class ToWebsiteSubfolderConversionTest
    {
        [Theory]
        [InlineData(
            @"website\App_Code\Repository\SQLRepository\ActivitySQLRepository.cs",
            @"App_Code\Repository\SQLRepository\ActivitySQLRepository.cs")]
        [InlineData(
            @"WEBSITE\App_Code\Repository\SQLRepository\ActivitySQLRepository.cs",
            @"App_Code\Repository\SQLRepository\ActivitySQLRepository.cs")]
        public void Test(string path, string expectedResult)
        {
            IPathConversion conversion = new ToWebsiteSubfolderConversion();
            string actualResult = conversion.ConvertPath(path);
            Assert.Equal(actualResult, expectedResult);
        }
    }
}
