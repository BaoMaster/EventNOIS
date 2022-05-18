using Event2206.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Event2206.Data.EF;

public class Event2206DbContext : DbContext
{
    public Event2206DbContext(DbContextOptions options)
       : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<User> Users { get; set; }
}
