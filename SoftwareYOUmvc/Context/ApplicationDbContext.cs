using SoftwareYOUmvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SoftwareYOUmvc.Context
{
    public class ApplicationDbContext:DbContext
    {
        //Podemos enviarles un Conexion string  public ApplicationDbContext() :base("miBase") { }
        public DbSet<Persona> Personas { get; set; }
        //enable-migrations => Activa
        //update-database  => Crea la BD => Cada vez que modifico algo


    }
}