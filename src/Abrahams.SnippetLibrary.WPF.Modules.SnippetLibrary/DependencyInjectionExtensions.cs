using Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels;

namespace Microsoft.Practices.Unity
{
    public static class DependencyInjectionExtensions
    {
        public static void AddSnippetLibraryModuleViewModel(this IUnityContainer container)
        {
            // TODO: Implement messaging between the two view models as a singleton shared app service.
            container.RegisterType<ISnippetLibraryViewModel, SnippetLibraryViewModel>();
            container.RegisterType<ISnippetEditDialogViewModel, SnippetEditDialogViewModel>();
        }
    }
}
