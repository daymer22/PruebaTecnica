using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Entidades;
using System;

namespace PruebaTecnica.AccesoADatos
{
    public class PruebaTecnicaContext : DbContext
    {
        public DbSet<Empresa> Empresa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-IJT6R94\\SQLEXPRESS; Database=PruebaTecnica; Trusted_Connection=True; MultipleActiveResultSets=true");
            }
        }
    }
}