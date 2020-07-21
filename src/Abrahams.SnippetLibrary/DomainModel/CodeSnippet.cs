using System.Collections.Generic;

namespace Abrahams.SnippetLibrary.DomainModel
{
    public class CodeSnippet
    {
        public string Description { get; set; } = string.Empty;
        public string CodeSample { get; set; } = string.Empty;
        public Language Language { get; set; } = new Language();
        public List<Tag> Tags { get; } = new List<Tag>();
        // TODO: Switch to nullable reference types c# 8 features
    }
}
