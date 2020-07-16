using Abrahams.SnippetLibrary.DomainModel;
using System.Collections.Generic;

namespace Abrahams.SnippetLibrary.DAL
{
    public interface ILanguageRepository
    {
        List<Language> GetLanguageList();
    }
}
