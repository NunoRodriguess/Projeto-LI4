using BirdBoxFull.Shared;
using Microsoft.EntityFrameworkCore;

namespace BirdBoxFull.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Utilizador> Utilizadores { get; set; }
        

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //    modelBuilder.Entity<Leilao>.HasData();
        //}

    }
}
