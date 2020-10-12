using System;
using buy_and_sell_dotNetAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace buy_and_sell_dotNetAPI.Data
{
    public class ApplicationDBContext : DbContext
    {

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseMySql("server=127.0.0.1;port=3306;user=root;password=Password123;database=buy-and-sell")
        //        .UseLoggerFactory(LoggerFactory.Create(b => b
        //            .AddConsole()
        //            .AddFilter(level => level > LogLevel.Information)))
        //        .EnableSensitiveDataLogging()
        //        .EnableDetailedErrors();
        //}

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opt) : base(opt)
        {

        }

        public DbSet<Listing> Listings { get; set; }
    }
}
