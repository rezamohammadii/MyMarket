using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StoneMarket.AccessLayer.Context;
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
            configuration.UseMySQL("server=localhost;port=3310;user=admin;password=V7McNe8g!D7wQrcg;database=mymarket");
            return new StoneMarketContext(configuration.Options);
        }
    }
}
