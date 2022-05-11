using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class LinkRepositoryAsync : GenericRepositoryAsync<Link>, ILinkRepositoryAsync
    {
        private readonly DbSet<Link> _link;

        public LinkRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _link = dbContext.Set<Link>();
        }
    }
}
