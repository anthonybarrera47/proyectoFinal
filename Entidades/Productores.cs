using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productores
    {
        [Key]
        public int ProductorID { get; set; }
        public String Nombre { get; set; }
        public String Telefono { get; set; }
        public String Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Productores()
        {
            ProductorID = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            FechaNacimiento = DateTime.Now;
            Cedula = string.Empty;
        }
        public Productores(int ProductorId, String Nombre, String Telefono, DateTime FechaNacimiento, String Cedula)
        {
            this.ProductorID = ProductorId;
            this.Nombre = Nombre;
            this.Telefono = Telefono;
            this.FechaNacimiento = FechaNacimiento;
            this.Cedula = Cedula;
        }
    }
}
