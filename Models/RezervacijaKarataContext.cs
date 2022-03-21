using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class RezervacijaKarataContext : DbContext
    {
        public DbSet<Koncert> Koncerti {get;set;}
        public DbSet<Izvodjac> Izvodjaci {get;set;}
        public DbSet<Sala> Sale {get;set;}
        public DbSet<Grad> Gradovi {get;set;}
        public DbSet<Rezervacija> Rezervacije {get;set;}
        public RezervacijaKarataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             
            modelBuilder.Entity<Koncert>()
                        .HasOne(s => s.Izvodjac);
            
            modelBuilder.Entity<Koncert>()
                        .HasOne(s => s.Sala)
                        .WithMany(s => s.Koncert);            
           
            modelBuilder.Entity<Sala>()
                        .HasOne(s => s.Grad);
            
        }
    }
}