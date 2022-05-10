using Core.Application.Helpers;
using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class SnippetRepositoryAsync : GenericRepositoryAsync<Snippet>, ISnippetRepositoryAsync
    {
        private readonly DbSet<Snippet> _snippets;

        public SnippetRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _snippets = dbContext.Set<Snippet>();
        }

        public override async Task<IReadOnlyList<Snippet>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _snippets
                .Where(i => i.Status != Status.DELETED)
                .Include(i => i.Tags)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Snippet> GetByIdAsync(int id)
        {
            return await _snippets.Include(p => p.Tags).FirstAsync(i => i.Id == id);
        }

        public async Task<IReadOnlyList<Snippet>> SearchSnippetByKeyword(string keyword, int pageNumber, int pageSize)
        {
            return await _snippets
                .Where(i => i.Name.Contains(keyword)
                    || i.Tags.Any(p => p.Name.Contains(keyword))
                    || i.Description.Contains(keyword)
                    || i.Origin.Contains(keyword)
                    || i.Language.Contains(keyword)
                    || i.CreateAt.ToString().Contains(keyword))
                .Include(i => i.Tags)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Snippet>> SearchByName(string name)
        {
            return await _snippets
                .Where(i => i.Name.Contains(name))
                .Include(i => i.Tags)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Snippet>> SearchByTags(string tag)
        {
            return await _snippets
                .Where(i => i.Tags.Any(i => i.Name.Contains(tag)))
                .Include(i => i.Tags)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Snippet>> SearchByDescription(string description)
        {
            return await _snippets
                .Where(i => i.Description.Contains(description))
                .Include(i => i.Tags)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Snippet>> SearchByOrigin(string origin)
        {
            return await _snippets
                .Where(i => i.Origin.Contains(origin))
                .Include(i => i.Tags)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Snippet>> SearchByCreateTime(DateTime time)
        {
            return await _snippets
                .Where(i => i.CreateAt == time)
                .Include(i => i.Tags)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
