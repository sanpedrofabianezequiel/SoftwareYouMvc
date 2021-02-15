using SoftwareYOUmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoftwareYOUmvc.Models;

namespace SoftwareYOUmvc.Controllers
{
    public class PersonasController : Controller
    {
        private readonly Context.ApplicationDbContext db = new Context.ApplicationDbContext();

        // GET: Personas
        public ActionResult Index()
        {
            return View(db.Personas.ToList());
        }
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

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id==null)
            {

            }
            return View();
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
