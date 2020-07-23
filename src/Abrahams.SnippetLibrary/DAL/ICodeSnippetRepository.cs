using Abrahams.SnippetLibrary.DomainModel;

namespace Abrahams.SnippetLibrary.DAL
{
    public interface ICodeSnippetRepository
    {
        CodeSnippet GetCodeSnippet(int codeSnippet);
        int SaveCodeSnippet(CodeSnippet model);
        // TODO: Save code snippet
    }
}
