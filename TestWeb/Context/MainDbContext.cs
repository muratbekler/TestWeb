using Microsoft.EntityFrameworkCore;
using TestWeb.Entities;

namespace TestWeb.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options) { }  

        public DbSet<Student> Students { get; set; }
    }
}
