using Abrahams.SnippetLibrary.DomainModel.IOC;
using Microsoft.Practices.Unity;

namespace Abrahams.SnippetLibrary.Test
{
    public abstract class UnitTestBase
    {
        protected IUnityContainer Container { get; } = ContainerFactory.CreateContainer();
    }
}
