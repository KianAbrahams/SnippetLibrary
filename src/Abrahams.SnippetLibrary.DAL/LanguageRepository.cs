using Abrahams.SnippetLibrary.DomainModel;
using System.Collections.Generic;

namespace Abrahams.SnippetLibrary.DAL
{
    public class LanguageRepository : ILanguageRepository
    {
        public List<Language> GetLanguageList()
        {
            // TODO: Load from a DB in place of sample date
            return new List<Language>()
            {
                new Language() { Id = 10, Name="XAML" },
                new Language() { Id = 20, Name="C#" },
                new Language() { Id = 30, Name="Java Script" }
            };
        }
    }
}
