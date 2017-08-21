using System;

namespace Deployer.Core.PathConversion
{
    public class ToWebsiteSubfolderConversion : IPathConversion
    {
        private const string WebsiteFolderName = @"website\";

        public string ConvertPath(string input)
        {
            if (input.ToUpper().StartsWith(WebsiteFolderName.ToUpper()))
            {
                return input.Substring(WebsiteFolderName.Length);
            }
            throw new InvalidOperationException(
                "Provided path does not look like a path within a website subfolder");
        }
    }
}
