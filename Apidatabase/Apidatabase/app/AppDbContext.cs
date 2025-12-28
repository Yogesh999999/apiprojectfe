using Apidatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace Apidatabase.app
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<newusers> Newusers { get; set; }
       
    }
}
