using SoftwareYOUmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using SoftwareYOUmvc.Models;
using System.Data.SqlClient;

namespace SoftwareYOUmvc.Controllers
{
    public class PersonasController : Controller
    {
        private readonly Context.ApplicationDbContext db = new Context.ApplicationDbContext();

        public class Estadisticas
        {
            public Sexo Sexo { get; set; }
            public int Cantidad { get; set; }
        }

        // GET: Personas
        public ActionResult Index()
        {
            return View(db.Personas.ToList());
        }
        #region Lazy Loading
        //public ActionResult Index()
        //{
        //    //
        //    var persona = db.Personas.FirstOrDefault();

        //    //Trae una persona con sus direcciones
        //    var personas = db.Personas.FirstOrDefault();
        //    var primeraDireccion = persona.Direcciones[0];


        //    //Trae todos las personas con sus direcciones
        //    var personasConDirecciones = db.Personas.ToList();
        //    var direccionD = personasConDirecciones[1].Direcciones[0];

        //    //Segundo Nivel
        //    var subCalle = persona.Direcciones[0].SubDireccion[0].SubCalle;

        //    //Problema de serializacion //Si tuviera Virtual
        //    var personaJSN = Newtonsoft.Json.JsonConvert.SerializeObject(persona);


        //    return View(db.Personas.ToList());
        //}
        #endregion
        #region EagerLoading +Include +Doble Lambda  +using System.Data.Entity;      
        //public ActionResult Index()
        //{
        //    //Error: Debemos utulza Include
        //    var persona = db.Personas.FirstOrDefault();
        //    var primeraDireccion = persona.Direcciones[0];


        //    //Include con Lambda + using System.Data.Entity;
        //    var personasInclude = db.Personas.Include(dir => dir.Direcciones).FirstOrDefault();
        //    var segundaDireccion = personasInclude.Direcciones[0];


        //    //Include con string
        //    var personaConDirecciones = db.Personas.Include("Direcciones").ToList();
        //    var direccionesDeLaSegunda = personaConDirecciones[1].Direcciones[0];


        //    //Include segundo Nivel
        //    var personasConDireSub = db.Personas.Include(x => x.Direcciones.Select(y => y.SubDireccion)).FirstOrDefault();
        //    var subCalle = personasConDireSub.Direcciones[0].SubDireccion[0].SubCalle;

        //    /////------------
        //    ///
        //    var personaLazy = db.Personas.Take(15000).ToList();//No usar ya que llama 15000+1n+1
        //    foreach (var item in personaLazy)
        //    {
        //        var calle = persona.Direcciones[0].Calle;
        //    }


        //    var personas = db.Personas.Include(x => x.Direcciones).ToList();
        //    foreach (var item in personas)
        //    {
        //        var calle = item.Direcciones[0].Calle;
        //    }

        //    return View(db.Personas.ToList());
        //}
        #endregion
        #region SQLQuery Query Arbitrario + SIN COLUMNA ESTADISTICA
        //public ActionResult Index()
        //{

        //    var personas = db.Personas.SqlQuery("SELECT * FROM dbo.Personas").ToList();

        //    var direccin = db.Database.SqlQuery<Direccion>(//Lo Mapea a un tipo Direccion
        //        @"SELECT *
        //            FROM dbo.Direccions
        //                WHERE CodigoDireccion = @Id",
        //                new SqlParameter("@Id", 1))  //using System.Data.SqlClient;
        //                    .FirstOrDefault();

        //    //----Sin TABLA QUE REPRESENTE LA CLASE ESTADISTICA
        //    var estadisticasSexo = db.Database.SqlQuery<Estadisticas>(
        //        @"SELECT 
        //             Sexo, count(*) as Cantidad
        //               FROM dbo.Personas 
        //                   GROUP BY Sexo "
        //        ).ToList();//Cantidad de Hombre y Mujeres que hay


        //    return View(db.Personas.ToList());
        //}
        #endregion
        #region InnerJoin Group Join+ToString() y sleccion de Columnas /GorupBy
        //public ActionResult Index()
        //{
        //    //Tabla + columna == columna + que vamos  a crear
        //    var personaDireccion = db.Direcciones.Join(db.Personas,
        //                    dir => dir.IdPersona,
        //                    per => per.Id,
        //                    (dir, per) => new { dir, per })//La informacion que quiero en ESTE ORDEN VA
        //                                                   //.Where(x => x.dir.CodigoDireccion == 1);
        //                    .FirstOrDefault(x => x.dir.CodigoDireccion == 1);
        //    //Group join
        //    var personaConsusDirecciones = db.Personas.GroupJoin(db.Direcciones,
        //        per => per.Id,
        //        dir => dir.IdPersona,
        //        (per, dir) => new { per, dir })
        //        .FirstOrDefault(x => x.per.Id == 1);

        //    //GroupJoin, traigo todas las dire
        //    var personasConSusDirecciones = db.Personas.GroupJoin(db.Direcciones,
        //        per => per.Id,
        //        dir => dir.IdPersona,
        //        (per, dir) => new { per, dir })
        //        .ToList();

        //    //Seleccion y groupBy
        //    var personas = db.Personas.ToString();
        //    var direccio = db.Direcciones.Select(x => new { x.CodigoDireccion, x.Calle }).ToString();
        //    var personaSexoMasculino = db.Personas.GroupBy(x => x.Sexo).ToString();
        //    return View(db.Personas.ToList());
        //}
        #endregion
        #region Include / Virtual
        //public ActionResult Index()//Insercion de una direccion en una persona
        //{
        //    //var persona = new Persona() { Id = 2 };
        //    //db.Personas.Attach(persona);
        //    //db.Direcciones.Add(new Direccion() { Calle = "Ejemplo 2", Persona = persona });
        //    //db.SaveChanges();

        //    //var persona = db.Personas.Include("Direcciones").FirstOrDefault(x => x.Id == 2);
        //    //var direcciones = persona.Direcciones;

        //    //var direccion = db.Direcciones.FirstOrDefault(x => x.CodigoDireccion == 4);
        //    //var nombre = direccion.Persona.Nombre;

        //    return View(db.Personas.ToList());
        //}
        #endregion
        #region Seleccion Columnas
        //public ActionResult Index()
        //{
        //    //Selecionar todas las columnas
        //    var listado = db.Personas.ToList();
        //    //Seleccionar varias columas y proyectandolas a un tipo ANONIMO
        //    var listado2 = db.Personas.Select(x => new { Nombre = x.Nombre,Edad =x.Edad }).ToList();
        //    //Seleccionar varias columnas y proyectandolas hacia una CLASE
        //    var listado3 = db.Personas.Select(x => new { Nombre = x.Nombre, Edad = x.Edad }).ToList()
        //        .Select(x => new Persona() { Nombre = x.Nombre, Edad = x.Edad }).ToList();    
        //}
        #endregion

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #region  DB   =>EntityFrameWork
        //[HttpPost]-----------------ADD
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Bind(Include = "Id,Nombre,Nacimiento,Edad")  Persona persona)
        //{
        //    if (ModelState.IsValid){
        //        db.Personas.Add(persona);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(persona);
        //}
        //[HttpPost]-----------------ADDRANGE
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(  Persona persona)
        //{
        //    if (ModelState.IsValid){
        //        var personas = new List<Persona>() { persona };
        //        personas.Add(new Persona() { Nombre = "Agregado", Edad = 454, Nacimiento = new DateTime(2020, 01, 01) });
        //        db.Personas.AddRange(personas);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //     }
        //    return View(persona);
        // }

        //[HttpPost]//-------------UPDATE
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    //Trae el objeto y lo actualiza
        //    var personaEditar = db.Personas.FirstOrDefault( x => x.Id ==2);
        //    personaEditar.Nombre = "Editado metodo 1";
        //    personaEditar.Edad = personaEditar.Edad + 1;
        //    db.SaveChanges();

        //    //Actualizcion parcial
        //    var personaEditar2 = new Persona();
        //    personaEditar2.Id = 3;
        //    personaEditar2.Nombre = "Editado metodo 2";
        //    personaEditar2.Edad = 54;
        //    db.Personas.Attach(personaEditar2);
        //    db.Entry(personaEditar2).Property(x => x.Nombre).IsModified = true;
        //    db.SaveChanges();

        //    //Objteo externo actualizado total
        //    db.Entry(collection).State = System.Data.Entity.EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //[HttpPost,ActionName("Delete")]//--------------DELETE
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    Persona persona = db.Personas.Find(id);
        //    db.Personas.Remove(persona);
        //    db.Personas.RemoveRange();
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        #endregion
        // GET: Personas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Personas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
