using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class ISDBContext(DbContextOptions options) 
    : DbContext(options)
{
    public DbSet<Activity> Activities { get;set; }
    public DbSet<Request> Requests {get; set;}
    public DbSet<User> Users {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ISDBContext).Assembly);
    }
}