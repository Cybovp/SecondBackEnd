using Microsoft.EntityFrameworkCore;
using SecondBackEnd.Models;

namespace SecondBackEnd.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
