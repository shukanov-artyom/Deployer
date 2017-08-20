using System;
using Deployer.Core.ActionItems;

namespace Deployer.Core.Sequence.ItemTypeInference
{
    public interface IDiffActionItemTypeInference
    {
        /// <summary>
        /// Infers whether a type of element (file, folder) which has been a target for a change in SVN diff.
        /// </summary>
        /// <returns>Inferred type.</returns>
        DiffActionItemTargetType Infer();
    }
}
