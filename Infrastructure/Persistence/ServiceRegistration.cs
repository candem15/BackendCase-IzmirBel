using Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.ConnectionStringSqlServer);
            });

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            // Automized migration.
            var optBuilder = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(Configuration.ConnectionStringSqlServer);
            using var dbContext = new AppDbContext(optBuilder.Options);

            dbContext.Database.Migrate();
            dbContext.Database.EnsureCreated();
        }
    }
}
