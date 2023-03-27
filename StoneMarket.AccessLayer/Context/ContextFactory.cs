using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneMarket.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<StoneMarketContext>
    {
        public StoneMarketContext CreateDbContext(string[] args)
        {
            var configuration = new DbContextOptionsBuilder<StoneMarketContext>();
            configuration.UseMySql(ServerVersion.Parse("10.10.3"));
            return new StoneMarketContext(configuration.Options);
        }
    }
}
