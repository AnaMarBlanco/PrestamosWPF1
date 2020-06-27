using Microsoft.EntityFrameworkCore;
using PrestamosWPF.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamosWPF.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Moras> Moras { get; set; }
        public DbSet<MorasDetalle> MorasDetalle { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = DATA/Database.db");
        }
    }
}
