using Microsoft.EntityFrameworkCore;

namespace TaskPractice.Data.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions ):base(dbContextOptions) {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }  
            
        }
    }

