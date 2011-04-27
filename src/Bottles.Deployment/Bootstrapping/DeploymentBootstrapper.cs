using System;
using Bottles.Exploding;
using Bottles.Zipping;
using FubuCore;
using StructureMap;

namespace Bottles.Deployment.Bootstrapping
{
    public static class DeploymentBootstrapper
    {
        public static IContainer Bootstrap(DeploymentSettings settings)
        {
            return new Container(x =>
            {
                x.For<IFileSystem>().Use<FileSystem>();

                x.For<IProfileFinder>().Use<ProfileFinder>();
                x.For<IPackageExploder>().Use<PackageExploder>();
                x.For<IZipFileService>().Use<ZipFileService>();
                x.For<IPackageExploderLogger>().Use(new PackageExploderLogger(Console.WriteLine));

                x.For<DeploymentSettings>().Use(settings);

                x.AddRegistry<DeploymentRegistry>();
                
            });
        }
    }
}

//512 574 8193