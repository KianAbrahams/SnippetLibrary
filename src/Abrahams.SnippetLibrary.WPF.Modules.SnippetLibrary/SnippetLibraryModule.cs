using Abrahams.SnippetLibrary.Modules.SnippetLibrary.Views;
using Abrahams.SnippetLibrary.Shared;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary
{
    public class SnippetLibraryModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;

        public SnippetLibraryModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {

            this.container.AddSnippetLibraryModuleUI();

            this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion, () => this.container.Resolve<SnippetLibraryView>());
        }
    }
}