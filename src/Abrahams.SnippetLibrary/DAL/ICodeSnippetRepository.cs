using Abrahams.SnippetLibrary.DomainModel;

namespace Abrahams.SnippetLibrary.DAL
{
    public interface ICodeSnippetRepository
    {
        CodeSnippet GetCodeSnippet(int codeSnippet);
        // TODO: Save code snippet
    }
}
