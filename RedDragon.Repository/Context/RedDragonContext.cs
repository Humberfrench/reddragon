using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata;
using RedDragon.Domain.Entity;
using static Microsoft.Extensions.Configuration.ConfigurationExtensions;
using static RedDragon.Repository.Maps.AviaoMap;

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
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("RedDragonContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(@"Server=.\Web17;Database=RedDragon;Trusted_Connection=True;");
            //    optionsBuilder.UseLazyLoadingProxies(false);
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapAviao(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}