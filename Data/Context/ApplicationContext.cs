using HelloPets.Data.Entities;
using Microsoft.EntityFrameworkCore;
using HelloPets.Data.EntitiesConfiguration;

namespace HelloPets.Data.Context;

public class ApplicationContext : DbContext
{
    public DbSet<User> Tutors { get; set; } = null!;
    public DbSet<Pet> Pets { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new PetConfiguration());
    }
}