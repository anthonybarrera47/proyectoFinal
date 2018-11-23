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
        public int TipoArrozId { get; set; }
        public String Descripcion { get; set; }
        public decimal Kilos { get; set; }

        public TipoArroz(int TipoArrozId,String Descripcion,decimal Kilos)
        {
            this.TipoArrozId = TipoArrozId;
            this.Descripcion = Descripcion;
            this.Kilos = Kilos;
        }
        public TipoArroz()
        {
            TipoArrozId = 0;
            Descripcion = string.Empty;
            Kilos = 0;
        }
    }
}
