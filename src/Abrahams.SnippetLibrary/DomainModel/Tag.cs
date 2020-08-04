using System.Collections.Generic;

namespace Abrahams.SnippetLibrary.DomainModel
{
    public class Tag
    {
        public int TagId { get; set; } = Constants.UnknownId;
        public string Name { get; set; } = string.Empty;
        public List<Tag> theList = new List<Tag>();
        public const int TagMaxLength = 255;
    }
}
