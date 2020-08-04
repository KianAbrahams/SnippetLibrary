using Abrahams.SnippetLibrary.DomainModel;
using System.Collections.Generic;

namespace Abrahams.SnippetLibrary.DAL
{
    public interface ITagRepository
    {
        List<Tag> GetTags();
        int SaveTag(Tag tag);
        // TODO: Move SaveTag into TagRepository from codeSnippetRepository.
        // TODO: Implement GetTags.
        // TODO: Register ITagRepository in DI.
        // TODO: Inject ITagRepository in TagPickerDialog.
    }
}
