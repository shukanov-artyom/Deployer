using System;
using Deployer.Core.PathConversion;
using Xunit;

namespace Deployer.Core.Test.PathConversion
{
    public class ToUnixPathConversionTest
    {
        [Fact]
        public void Test()
        {
            string input = @"website\App_Code\Enums\Cases\";
            string expectedResult = @"website/App_Code/Enums/Cases/";
            var conversion = new ToUnixPathConversion();
            string result = conversion.ConvertPath(input);
            Assert.Equal(result, expectedResult);
        }
    }
}
