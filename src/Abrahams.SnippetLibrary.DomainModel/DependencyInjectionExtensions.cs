using Abrahams.SnippetLibrary.DomainModel.Validation;

namespace Microsoft.Practices.Unity
{
    public static class DependencyInjectionExtensions
    {
        public static void AddSnippetLibraryDomainModel(this IUnityContainer container)
        {
            container.RegisterType<ITagValidator, TagValidator>();
            container.RegisterType<ILanguageValidator, LanguageValidator>();
            container.RegisterType<ICodeSnippetValidator, CodeSnippetValidator>();
            container.RegisterType<ICodeSnippetSearchCriteriaValidator, CodeSnippetSearchCriteriaValidator>();
        }
    }
}