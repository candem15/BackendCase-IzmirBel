using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public DesignTimeDbContextFactory()
        {

        }
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString = Configuration.ConnectionStringSqlServer;

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }

}
