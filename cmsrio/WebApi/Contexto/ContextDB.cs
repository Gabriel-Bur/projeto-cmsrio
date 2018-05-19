using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Migrations;
using WebApi.Models;

namespace WebApi.Contexto
{
    public class ContextDB : DbContext
    {

        public ContextDB() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ContextDB>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContextDB, ConfigurationMigration>());

        }

        public DbSet<Hospital> Hospitais { get; set; }

        public DbSet<Avaliacao> Avaliacoes { get; set; }
    }
}