using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class SnippetRepositorAsync : GenericRepositoryAsync<Snippet>, ISnippetRespositoryAsync
    {
        private readonly DbSet<Snippet> snippets;

        public SnippetRepositorAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            snippets = dbContext.Set<Snippet>();
        }
    }
}
