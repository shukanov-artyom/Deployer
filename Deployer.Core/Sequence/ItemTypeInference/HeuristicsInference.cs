using System;
using System.Collections.Generic;
using System.Linq;
using Deployer.Core.ActionItems;

namespace Deployer.Core.Sequence.ItemTypeInference
{
    public class HeuristicsInference : IDiffActionItemTypeInference
    {
        private static readonly List<string> ExpectedFileExtensions =
            new List<string>()
            {
                ".cs",
                ".aspx",
                ".ascx",
                ".asax",
                ".ashx",
                ".cshtml",
                ".master",
                ".html",
                ".js",
                ".json",
                ".svg",
                ".png",
                ".gif",
                ".jpeg",
                ".jpg",
                ".less",
                ".css",
                ".htm",
                ".txt",
                ".ts"
            }.Select(el => el.ToUpper())
            .ToList();

        private readonly ApplicationOptions options;

        public HeuristicsInference(ApplicationOptions options)
        {
            this.options = options;
        }

        public DiffActionItemTargetType Infer(string path)
        {
            path = path.ToUpper();
            if (ExpectedFileExtensions.Any(path.EndsWith))
            {
                return DiffActionItemTargetType.File;
            }
            return DiffActionItemTargetType.Folder;
        }
    }
}
