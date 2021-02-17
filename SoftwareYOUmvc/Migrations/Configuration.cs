namespace SoftwareYOUmvc.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SoftwareYOUmvc.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            #region Estructura para utilizar AutomaticMigrationsEnabled = false; //Correcot

            AutomaticMigrationsEnabled = false;

            //Add-Migration "Name" 
            //Update-Database
            //update-database -NameMigracion  Resutl= Reverting Migrations
            #endregion



            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;//No recomendado=> para que no avise la perdida de DATA
        }

        protected override void Seed(SoftwareYOUmvc.Context.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
