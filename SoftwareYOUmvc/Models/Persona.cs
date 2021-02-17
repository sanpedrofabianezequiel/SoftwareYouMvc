using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftwareYOUmvc.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Nacimiento { get; set; }
        public int Edad { get; set; }
        public Sexo Sexo { get; set; }
        public  List<Direccion> Direcciones { get; set; }
    }
    public enum Sexo
    {
        Masculino=1,
        Femenino=2
    }
}