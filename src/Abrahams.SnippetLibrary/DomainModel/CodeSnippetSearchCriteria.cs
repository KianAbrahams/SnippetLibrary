namespace Abrahams.SnippetLibrary.DomainModel
{
    public class CodeSnippetSearchCriteria
    {
        public string Description { get; set; } = string.Empty;
        public Language Language { get; set; } = new Language();
        public string CodeSample { get; set; } = string.Empty;
        public const int DescriptionMaxLength = 255;
    }
}
