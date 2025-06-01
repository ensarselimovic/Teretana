using ISTeretana.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IS_teretana.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet <Admin> Admin { get; set; }   
        public DbSet <Clan> Clan { get; set; }
        public DbSet <Izvjestaj> Izvjestaj { get; set; }
        public DbSet <Napredak> Napredak { get; set; }
        public DbSet <PlanTreninga> PlanTreninga { get; set; }
        public DbSet<Poruka> Poruka { get; set; }
        public DbSet<PovratnaInformacija>PovratnaInformacija { get; set; }
        public DbSet<Teretana>Teretana { get; set; }
        public DbSet<TerminTreninga>TerminTreninga { get; set; }
        public DbSet <Trener>Trener { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Clan>().ToTable("Clan");
            modelBuilder.Entity<Izvjestaj>().ToTable("Izvjestaj");
            modelBuilder.Entity<Napredak>().ToTable("Napredak");
            modelBuilder.Entity<PlanTreninga>().ToTable("PlanTreninga");
            modelBuilder.Entity<Poruka>().ToTable("Poruka");
            modelBuilder.Entity<PovratnaInformacija>().ToTable("PovratnaInformacija");
            modelBuilder.Entity<Teretana>().ToTable("Teretana");
            modelBuilder.Entity<TerminTreninga>().ToTable("TerminTreninga");
            modelBuilder.Entity<Trener>().ToTable("Trener");
            base.OnModelCreating(modelBuilder);
        }
    }
}
