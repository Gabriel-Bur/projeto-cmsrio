using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using WebApi.Contexto;


namespace WebApi.Migrations
{

    public class ConfigurationMigration : DbMigrationsConfiguration<ContextDB>
    {
        public ConfigurationMigration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(ContextDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
