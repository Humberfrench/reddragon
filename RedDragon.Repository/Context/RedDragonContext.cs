using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using System.Data.Entity;
using RedDragon.Domain.Entity;
using static Microsoft.Extensions.Configuration.ConfigurationExtensions;

namespace RedDragon.Repository.Context
{
    public partial class RedDragonContext : DbContext
    {

        public RedDragonContext()
        {
            //this.
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
        }

        public RedDragonContext(DbContextOptions<RedDragonContext> options)
            : base(options)
        {
        }
       
        public DbSet<Aviao> Aviao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\Web17;Database=RedDragon;Trusted_Connection=True;");
                optionsBuilder.UseLazyLoadingProxies(false);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Aviao>(entity =>
            {
                entity.HasKey(e => e.AviaoId);
                entity.Property(e => e.DataCriacao)
                      .HasColumnName("DataCriacao")
                      .HasColumnType("datetime")
                      .IsRequired();

                entity.Property(e => e.QuantidadeDePassageiros)
                      .HasColumnName("QuantidadeDePassageiros")
                      .HasColumnType("int")
                      .IsRequired();

                entity.Property(e => e.Modelo)
                      .HasColumnName("Modelo")
                      .IsRequired()
                      .HasMaxLength(50)
                      .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}