using Abrahams.SnippetLibrary.DomainModel;
using System.Collections.Generic;

namespace Abrahams.SnippetLibrary.DAL
{
    public interface ICodeSnippetRepository
    {
        CodeSnippet GetCodeSnippet(int codeSnippet);
        int SaveCodeSnippet(CodeSnippet model);
        List<CodeSnippetSearchResult> SearchForCodeSnippets(CodeSnippetSearchCriteria codeSnippetSearchCriteria);
    }
}
