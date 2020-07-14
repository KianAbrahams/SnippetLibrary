using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Abrahams.SnippetLibrary.WPF.Modules.SnippetLibrary
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
            // this.regionManager.RegisterViewWithRegion("MainRegion", () => this.container.Resolve<SnippetLibraryView>());
            this.regionManager.RegisterViewWithRegion("MainRegion", () => this.container.Resolve<SnippetEditView>());
        }
    }
}
