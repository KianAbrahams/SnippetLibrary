using Abrahams.SnippetLibrary.Modules.SnippetLibrary.Services;
using Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels;

namespace Microsoft.Practices.Unity
{
    public static class DependencyInjectionExtensions
    {
        public static void AddSnippetLibraryModuleViewModel(this IUnityContainer container)
        {
            container.RegisterType<ISnippetLibraryStateStore, SnippetLibraryStateStore>(new ContainerControlledLifetimeManager());

            container.RegisterType<ITagPickerDialogViewModel, TagPickerDialogViewModel>();
            container.RegisterType<ISnippetEditDialogViewModel, SnippetEditDialogViewModel>();
            container.RegisterType<ISnippetLibraryViewModel, SnippetLibraryViewModel>();
        }
    }
}
