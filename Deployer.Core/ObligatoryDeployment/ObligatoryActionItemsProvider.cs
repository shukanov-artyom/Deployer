using System;
using System.Collections.Generic;
using System.IO;
using Deployer.Core.ActionItems;

namespace Deployer.Core.ObligatoryDeployment
{
    public class ObligatoryActionItemsProvider
    {
        private readonly ObligatoryDeploymentsConfiguration configuration;

        public ObligatoryActionItemsProvider(
            ObligatoryDeploymentsConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<DiffActionItem> Items
        {
            get
            {
                foreach (var fileGroup in configuration.Groups)
                {
                    foreach (var file in fileGroup.Filenames)
                    {
                        yield return new DiffActionItem(
                            DiffActionItemTargetType.File,
                            DiffActionType.Modified,
                            Path.Combine(fileGroup.SourceFolder, file))
                        {
                            ItemRelativePathTarget = $"{fileGroup.TargetFolder}/{file}"
                        };
                    }
                }
        }
        }
    }
}
