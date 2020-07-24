namespace Abrahams.SnippetLibrary.DomainModel
{
    public class CodeSnippetSearchResult
    {
        public int CodeSnippetId { get; set; } = Constants.UnknownId;
        public string Description { get; set; } = string.Empty;
        public string CodeSample { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
    }
}
