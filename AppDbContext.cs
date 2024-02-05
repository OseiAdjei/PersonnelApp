using App.Domain;
using Microsoft.EntityFrameworkCore;

namespace App
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
        public DbSet<College> College { get; set; }
        public DbSet<Faculty> Faculty { get; set;}
        public DbSet<Department> Department { get; set; } 
        public DbSet<Nsp> Nsp { get; set; }
    }
}
