using System;
using Abrahams.SnippetLibrary.DomainModel;

namespace Abrahams.SnippetLibrary.Modules.SnippetLibrary.Services
{
    public interface ISnippetLibraryStateStore
    {
        event EventHandler<CodeSnippet> EditCodeSnippet;
        event EventHandler<CodeSnippet> AddTag;

        void OnEditCodeSnippet(CodeSnippet codeSnippet);
        void OnAddTag(CodeSnippet codeSnippet);
    }
    internal class SnippetLibraryStateStore : ISnippetLibraryStateStore
    {
        public event EventHandler<CodeSnippet> EditCodeSnippet;
        public event EventHandler<CodeSnippet> AddTag;

        public void OnEditCodeSnippet(CodeSnippet codeSnippet) => this.EditCodeSnippet?.Invoke(this, codeSnippet);
        public void OnAddTag(CodeSnippet codeSnippet) => this.AddTag?.Invoke(this, codeSnippet);
    }
}
