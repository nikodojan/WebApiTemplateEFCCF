using Microsoft.EntityFrameworkCore;
using WebApiTemplateV1.Models;

namespace WebApiTemplateV1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        // TODO: Create DbSet<T> properties
        public DbSet<Item> Items { get; set; }


    }
}
