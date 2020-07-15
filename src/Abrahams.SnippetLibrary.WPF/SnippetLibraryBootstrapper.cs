using System.Windows;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Modularity;
using Abrahams.SnippetLibrary.DomainModel.IOC;
using Abrahams.SnippetLibrary.WPF.Modules.SnippetLibrary;

namespace Abrahams.SnippetLibrary.WPF
{
    public class SnippetLibraryBootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            ContainerFactory.CreateContainer(this.Container);

            // Set up DI registration for types in this project
            this.Container.RegisterType<MainWindow>(new ContainerControlledLifetimeManager());
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