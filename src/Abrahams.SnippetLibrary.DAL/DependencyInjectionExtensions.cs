using Abrahams.SnippetLibrary.DAL;

namespace Microsoft.Practices.Unity
{
    public static class DependencyInjectionExtensions
    {
        public static void AddSnippetLibraryDAL(this IUnityContainer container)
        {
            container.RegisterType<ILanguageRepository, LanguageRepository>();
        }
    }
}