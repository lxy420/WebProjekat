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
        public DbSet<KoncertIzvodjac> KoncertIzvodjac {get;set;}
        public RezervacijaKarataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<KoncertIzvodjac>()
                        .HasOne(k => k.Koncert)
                        .WithMany(ki => ki.KoncertIzvodjac)
                        .HasForeignKey(kid => kid.KoncertId);

            modelBuilder.Entity<KoncertIzvodjac>()
                        .HasOne(i => i.Izvodjac)
                        .WithMany(ki => ki.KoncertIzvodjac)
                        .HasForeignKey(iid => iid.IzvodjacId);
            
            modelBuilder.Entity<Koncert>()
                        .HasOne(s => s.Sala)
                        .WithMany(s => s.Koncert);            
           
            modelBuilder.Entity<Sala>()
                        .HasOne(s => s.Grad);
                                                                        
            modelBuilder.Entity<Rezervacija>()
                        .HasOne(s => s.Koncert);
                        
            
        }
    }
}