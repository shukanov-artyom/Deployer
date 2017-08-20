using System;
using System.Collections;
using System.Collections.Generic;

namespace Deployer.Core.Filtering
{
    public class DefaultFilterCollection : IEnumerable<IActionItemFilter>
    {
        public IEnumerator<IActionItemFilter> GetEnumerator()
        {
            yield return new SqlScriptsFilter();
            yield return new WebsiteFolderContentsFilter();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
