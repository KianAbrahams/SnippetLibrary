using Abrahams.SnippetLibrary.DomainModel.Validation;
using Microsoft.Practices.Unity;

namespace Abrahams.SnippetLibrary.DomainModel.IOC
{
    public class ContainerFactory
    {
        public static UnityContainer CreateContainer(UnityContainer container)
        {
            container.RegisterType<ITagValidator, TagValidator>();
            container.RegisterType<ILanguageValidator, LanguageValidator>();
            container.RegisterType<ICodeSnippetValidator, CodeSnippetValidator>();
            return container;
        }

        public static UnityContainer CreateContainer() => CreateContainer(new UnityContainer());
    }
}
