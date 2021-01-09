using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SuiviClientCovid.ORM
{
    public class Contexte : DbContext
    {
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Injection> Injections { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=vaccinator.db");
        }
    }
}
