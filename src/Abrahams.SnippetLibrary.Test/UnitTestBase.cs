using Microsoft.Practices.Unity;

namespace Abrahams.SnippetLibrary.Test
{
    public abstract class UnitTestBase
    {
        protected IUnityContainer Container { get; } = new UnityContainer();

        public UnitTestBase()
        {
            this.Container.AddSnippetLibraryDAL();
            this.Container.AddSnippetLibraryDomainModel();
            this.Container.AddSnippetLibraryModuleViewModel();
        }
    }
}
