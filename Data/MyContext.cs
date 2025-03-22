using BoniboNews.Models;
using Microsoft.EntityFrameworkCore;
using BoniboNews.DateTime;

namespace BoniboNews.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public DbSet<Items> Items { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
