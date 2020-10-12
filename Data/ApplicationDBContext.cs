using System;
using buy_and_sell_dotNetAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace buy_and_sell_dotNetAPI.Data
{
    public class ApplicationDBContext : DbContext
    {


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opt) : base(opt)
        {

        }

        public DbSet<Listing> Listings { get; set; }
    }
}
