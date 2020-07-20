using Abrahams.SnippetLibrary.DAL;
using Abrahams.SnippetLibrary.DAL.SqlClient;

namespace Microsoft.Practices.Unity
{
    public static class DependencyInjectionExtensions
    {
        public static void AddSnippetLibraryDAL(this IUnityContainer container)
        {
            container.RegisterType<ILanguageRepository, SqlClientLanguageRepository>();
        }
    }
}