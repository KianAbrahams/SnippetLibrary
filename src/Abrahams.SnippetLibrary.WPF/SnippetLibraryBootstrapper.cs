using System.Windows;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using Abrahams.SnippetLibrary.Modules.SnippetLibrary;

namespace Abrahams.SnippetLibrary
{
    public class SnippetLibraryBootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Setup Core DI ...
            this.Container.AddSnippetLibraryDAL();
            this.Container.AddSnippetLibraryDomainModel();

            // Set up DI registration for types in this project ...
            this.Container.RegisterType<MainWindow>(new ContainerControlledLifetimeManager());

            // Each module will then add its own registrations in the module itself.
        }

        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(SnippetLibraryModule));
        }
    }
}