using Core.Application.Helpers;
using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class SnippetRepositoryAsync : GenericRepositoryAsync<Snippet>, ISnippetRespositoryAsync
    {
        private readonly DbSet<Snippet> _snippets;

        public SnippetRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _snippets = dbContext.Set<Snippet>();
        }

        /// <summary>
        /// Get paged snippets
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public override async Task<IReadOnlyList<Snippet>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _snippets
                .Where(i => i.Status != Status.DELETED)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Search snippet by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<Snippet>> SearchByName(string name)
        {
            return await _snippets
                .Where(i => i.Name.Contains(name))
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Search snippet by tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<Snippet>> SearchByTags(string tag)
        {
            return await _snippets
                .Where(i => i.Tags.Contains(tag))
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Search snippet by description
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<Snippet>> SearchByDescription(string description)
        {
            return await _snippets
                .Where(i => i.Description.Contains(description))
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Search snippet by origin
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<Snippet>> SearchByOrigin(string origin)
        {
            return await _snippets
                .Where(i => i.Origin.Contains(origin))
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Search snippet by create time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<Snippet>> SearchByCreateTime(DateTime time)
        {
            return await _snippets
                .Where(i => i.CreateAt == time)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
