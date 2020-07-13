using Abrahams.SnippetLibrary.DomainModel.Validation;
using Microsoft.Practices.Unity;

namespace Abrahams.SnippetLibrary.DomainModel.IOC
{
    public class ContainerFactory
    {
        public static IUnityContainer CreateContainer(IUnityContainer container)
        {
            container.RegisterType<ITagValidator, TagValidator>();
            container.RegisterType<ILanguageValidator, LanguageValidator>();
            container.RegisterType<ICodeSnippetValidator, CodeSnippetValidator>();
            return container;
        }

        public static IUnityContainer CreateContainer() => CreateContainer(new UnityContainer());
    }
}
