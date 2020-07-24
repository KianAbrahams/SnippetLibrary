using System.Collections.Generic;

namespace Abrahams.SnippetLibrary.DomainModel
{
    public class CodeSnippet
    {
        public int CodeSnippetId { get; set; } = Constants.UnknownId;
        public string Description { get; set; } = string.Empty;
        public string CodeSample { get; set; } = string.Empty;
        public Language Language { get; set; } = new Language();
        public List<Tag> Tags { get; } = new List<Tag>();
        public const int DescriptionMaxLength = 255;
        // TODO: Switch to nullable reference types c# 8 features
    }
}
