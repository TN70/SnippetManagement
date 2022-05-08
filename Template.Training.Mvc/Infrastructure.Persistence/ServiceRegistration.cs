using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(
                 configuration.GetConnectionString("DefaultConnection"),
                 b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //services.AddHttpContextAccessor();
            //services.AddSingleton<IUriService>(o =>
            //{
            //    var accessor = o.GetRequiredService<IHttpContextAccessor>();
            //    var request = accessor.HttpContext.Request;
            //    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
            //    return new UriService(uri);
            //});

            #region Repositories
            //services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            //services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();
            //services.AddTransient<IPostRepositoryAsync, PostRepositoryAsync>();
            #endregion
        }
    }
}
