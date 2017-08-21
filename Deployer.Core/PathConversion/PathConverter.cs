using System;
using System.Collections.Generic;

namespace Deployer.Core.PathConversion
{
    public class PathConverter
    {
        private readonly IEnumerable<IPathConversion> conversions;

        public PathConverter(IEnumerable<IPathConversion> conversions)
        {
            this.conversions = conversions;
        }

        public string Convert(string path)
        {
            foreach (var conversion in conversions)
            {
                path = conversion.ConvertPath(path);
            }
            return path;
        }
    }
}
