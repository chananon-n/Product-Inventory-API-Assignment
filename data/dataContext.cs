using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Product>()
        //     .Property(p => p.SKU)
        //     .IsUnique();
        // modelBuilder.Entity<User>()
        // .Property(u => u.Username)
        //     .IsUnique();
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

}
