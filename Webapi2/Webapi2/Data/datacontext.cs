
using Microsoft.EntityFrameworkCore;
using Webapi2.Entity;

namespace Webapi2.Data
{
    public class datacontext : DbContext
    {
        public datacontext(DbContextOptions<datacontext> options) : base(options)
        {

        }

        public DbSet<Practice> practices { get; set; }
    }
}
