using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class TiposArroz
    {
        [Key]
        public int TipoArrozId { get; set; }
        public String Descripcion { get; set; }

        public TiposArroz(int TipoArrozId,String Descripcion)
        {
            this.TipoArrozId = TipoArrozId;
            this.Descripcion = Descripcion;
        }
        public TiposArroz()
        {
            TipoArrozId = 0;
            Descripcion = string.Empty;
        }
    }
}
