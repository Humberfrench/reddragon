using Microsoft.EntityFrameworkCore;
using RedDragon.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedDragon.Repository.Maps
{
    public static class AviaoMap
    {
        public static void MapAviao(ModelBuilder modelBuilder)
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

        }
    }
}
