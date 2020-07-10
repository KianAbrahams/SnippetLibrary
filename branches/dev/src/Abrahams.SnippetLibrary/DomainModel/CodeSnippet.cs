using System.Collections.Generic;

namespace Abrahams.SnippetLibrary.DomainModel
{
    public class CodeSnippet
    {
        public string Description { get; set; }
        public string CodeSample { get; set; }
        public Language Language { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        // TODO: Switch to nullable reference types c# 8 feature
        // TODO: switch to readonly property with behaviour methods 
    }
}
