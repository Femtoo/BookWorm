using BookWormWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWormWeb.Data
{
    public class ApplicationDatabaseContext : DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
