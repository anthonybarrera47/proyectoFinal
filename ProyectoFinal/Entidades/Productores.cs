using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Productores
    {
        [Key]
        public int ProductorId { get; set; }
        public String Nombre { get; set; }
        public String Telefono { get; set; }
        public String Cedula { get; set; }
        public Decimal Balance { get; set; }
        public DateTime FechaNacimiento { get; set; }
        

        public Productores()
        {
            ProductorId = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Balance = 0;
            FechaNacimiento = DateTime.Now;
            Cedula = string.Empty;
        }
        public Productores(int ProductorId,String Nombre,String Telefono,Decimal Balance, DateTime FechaNacimiento,String Cedula)
        {
            this.ProductorId = ProductorId;
            this.Nombre = Nombre;
            this.Telefono = Telefono;
            this.Balance = Balance;
            this.FechaNacimiento = FechaNacimiento;
            this.Cedula = Cedula;
        }
    }
}
