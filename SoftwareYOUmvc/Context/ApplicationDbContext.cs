using SoftwareYOUmvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace SoftwareYOUmvc.Context
{
    public class ApplicationDbContext:DbContext
    {
        //Podemos enviarles un Conexion string  public ApplicationDbContext() :base("miBase") { }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        //enable-migrations => Activa
        //update-database  => Crea la BD => Cada vez que modifico algo

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Properties<DateTime>()
        //        .Configure(x => x.HasColumnType("datatime2"));//Cambia las prop DATATIME por DATETIME2

        //    modelBuilder.Properties<int>()
        //        .Where(p => p.Name.StartsWith("Codigo"))
        //            .Configure( p => p.IsKey());//Las prop Codigo las setea como PK

        //    base.OnModelCreating(modelBuilder);
        //}

        //protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)//Si estamos validando
        //{
        //    if (entityEntry.State == EntityState.Deleted)//Aca si se validan
        //    {
        //        return true;
        //    }
        //    return base.ShouldValidateEntity(entityEntry); //Las entidades que se borran NO SE VALIDAN
        //}

        //protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        //{
        //    if (entityEntry.Entity is Persona && entityEntry.State == EntityState.Deleted)
        //    {
        //        var entidad = entityEntry.Entity as Persona;//Si el OBJ es persona lo convierto en PERSONA
        //        if (entidad.Edad < 18)//Validamos que no se puedan borrar <18 en EntityFramework
        //        {
        //            return new DbEntityValidationResult(entityEntry,
        //                new DbValidationError[] { 
        //                    new DbValidationError("Edad","No se puede borrar a un menor de edad")
        //                    }
        //                );
        //        }
        //    }

        //    return base.ValidateEntity(entityEntry, items);//
        //}
        //public override int SaveChanges()
        //{
        //    var entidades = ChangeTracker.Entries();//Intercepta cualquier operacion
        //    if (entidades != null)
        //    {
        //        foreach (var item in entidades.Where( c=>c.State != EntityState.Unchanged))
        //        {
        //            //Logica de Auditoria
        //        }
        //    }


        //    return base.SaveChanges();
        //}

    }
}