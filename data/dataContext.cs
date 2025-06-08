using Microsoft.EntityFrameworkCore;

#pragma warning disable CS1591
public class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

}
#pragma warning restore CS1591
