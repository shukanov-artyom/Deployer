using System;
using Deployer.Core.ActionItems;
using Deployer.Core.ToCmd;
using Xunit;

namespace Deployer.Core.Test.ToCmd
{
    public class ToCmdConverterFactoryTest
    {
        [Fact]
        public void TestFileDeleted()
        {
            var options = new ApplicationOptionsTestProvider().Provide();
            var item = new DiffActionItem(
                DiffActionItemTargetType.File,
                DiffActionType.Deleted,
                @"App_Code/Views");
            var factory = new ToCmdConverterFactory(options, item);
            var result = factory.Create();
            Assert.IsType<FileDeletedToCmdConverter>(result);
        }

        [Fact]
        public void TestFileAdded()
        {
            var options = new ApplicationOptionsTestProvider().Provide();
            var item = new DiffActionItem(
                DiffActionItemTargetType.File,
                DiffActionType.Added,
                @"App_Code/Views");
            var factory = new ToCmdConverterFactory(options, item);
            var result = factory.Create();
            Assert.IsType<FileAddedToCmdConverter>(result);
        }

        [Fact]
        public void TestFileModified()
        {
            var options = new ApplicationOptionsTestProvider().Provide();
            var item = new DiffActionItem(
                DiffActionItemTargetType.File,
                DiffActionType.Modified,
                @"App_Code/Views");
            var factory = new ToCmdConverterFactory(options, item);
            var result = factory.Create();
            Assert.IsType<FileModifiedToCmdConverter>(result);
        }

        [Fact]
        public void TestFolderAdded()
        {
            var options = new ApplicationOptionsTestProvider().Provide();
            var item = new DiffActionItem(
                DiffActionItemTargetType.Folder,
                DiffActionType.Added,
                @"App_Code/Views");
            var factory = new ToCmdConverterFactory(options, item);
            var result = factory.Create();
            Assert.IsType<FolderAddedToCmdConverter>(result);
        }

        [Fact]
        public void TestFolderDeleted()
        {
            var options = new ApplicationOptionsTestProvider().Provide();
            var item = new DiffActionItem(
                DiffActionItemTargetType.Folder,
                DiffActionType.Deleted,
                @"App_Code/Views");
            var factory = new ToCmdConverterFactory(options, item);
            var result = factory.Create();
            Assert.IsType<FolderDeletedToCmdConverter>(result);
        }
    }
}
