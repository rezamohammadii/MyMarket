using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StoneMarket.AccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneMarket.AccessLayer.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<StoneMarketContext>
    {

        public StoneMarketContext CreateDbContext(string[] args)
        {

            var configuration = new DbContextOptionsBuilder<StoneMarketContext>();
            configuration.UseSqlite("Data Source=StoneMarket.db");
            return new StoneMarketContext(configuration.Options);
        }
    }
}
