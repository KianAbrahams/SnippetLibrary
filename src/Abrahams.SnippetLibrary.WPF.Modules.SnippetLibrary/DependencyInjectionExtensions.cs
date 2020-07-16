using Abrahams.SnippetLibrary.Modules.SnippetLibrary.Views;
using Abrahams.SnippetLibrary.Modules.SnippetLibrary.ViewModels;

namespace Microsoft.Practices.Unity
{
    public static class DependencyInjectionExtensions
    {
        public static void AddSnippetLibraryModuleUI(this IUnityContainer container)
        {
            container.RegisterType<SnippetEditDialog>();
            container.RegisterType<ISnippetLibraryViewModel, SnippetLibraryViewModel>();
            container.RegisterType<ISnippetEditDialogViewModel, SnippetEditDialogViewModel>();
        }
    }
}
