using System;
using Abrahams.SnippetLibrary.DomainModel;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.Services
{
    public interface ISnippetLibraryStateStore
    {
        event EventHandler<CodeSnippet> EditCodeSnippet;

        void OnEditCodeSnippet(CodeSnippet codeSnippet);
    }
    internal class SnippetLibraryStateStore : ISnippetLibraryStateStore
    {
        public event EventHandler<CodeSnippet> EditCodeSnippet;

        public void OnEditCodeSnippet(CodeSnippet codeSnippet) => this.EditCodeSnippet?.Invoke(this, codeSnippet);
    }
}
