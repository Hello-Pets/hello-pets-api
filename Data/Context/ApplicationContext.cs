using Data.Entities;
using HelloPets.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelloPets.Data.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Tutor> Tutors { get; set; } = null!;
    public DbSet<Pet> Pets { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "BancoDeDadosEmMemoria");
    }
}