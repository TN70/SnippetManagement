using Core.Domain.Entities;

namespace Core.Application.Interfaces.Repositories
{
    public interface ISnippetRepositoryAsync : IGenericRepositoryAsync<Snippet>
    {
        public Task<IReadOnlyList<Snippet>> SearchSnippetByKeyword(string keyword, int pageNumber, int pageSize);
        public Task<IReadOnlyList<Snippet>> SearchByName(string name);
        public Task<IReadOnlyList<Snippet>> SearchByTags(string tag);
        public Task<IReadOnlyList<Snippet>> SearchByDescription(string description);
        public Task<IReadOnlyList<Snippet>> SearchByOrigin(string tag);
        public Task<IReadOnlyList<Snippet>> SearchByCreateTime(DateTime time);
    }
}
