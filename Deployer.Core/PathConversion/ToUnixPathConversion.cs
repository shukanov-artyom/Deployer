using System;

namespace Deployer.Core.PathConversion
{
    public class ToUnixPathConversion : IPathConversion
    {
        public string ConvertPath(string input)
        {
            return input.Replace(@"\", @"/");
        }
    }
}
