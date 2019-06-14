using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class TipoArroz
    {
        [Key]
        public int TipoArrozID { get; set; }
        public String Descripcion { get; set; }
        public decimal Kilos { get; set; }
        public DateTime FechaRegistro { get; set; }

        public TipoArroz(int TipoArrozID,String Descripcion,decimal Kilos,DateTime FechaRegistro)
        {
            this.TipoArrozID = TipoArrozID;
            this.Descripcion = Descripcion;
            this.Kilos = Kilos;
            this.FechaRegistro = FechaRegistro;
        }
        public TipoArroz()
        {
            TipoArrozID = 0;
            Descripcion = string.Empty;
            Kilos = 0;
            FechaRegistro = DateTime.Now;
        }
    }
}
