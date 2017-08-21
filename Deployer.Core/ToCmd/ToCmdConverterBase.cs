using System;

namespace Deployer.Core.ToCmd
{
    public abstract class ToCmdConverterBase
    {
        protected ToCmdConverterBase(
            ApplicationOptions options)
        {
            this.Options = options;
        }

        protected ApplicationOptions Options { get; }
    }
}
