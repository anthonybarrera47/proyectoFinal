using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PesadasDetalle
    {
        [Key]
        public int PesadaDetalleID { get; set; }
        public int PesadasID { get; set; }
        public int TipoArrozID { get; set; }
        public decimal Kilos { get; set; }
        public decimal CantidadDeSacos { get; set; }
        [ForeignKey("TipoArrozID")]
        public virtual TipoArroz TipoArroz { get; set; }
        public PesadasDetalle()
        {
            PesadaDetalleID = 0;
            PesadasID = 0;
            TipoArrozID = 0;
            Kilos = 0;
            CantidadDeSacos = 0;
        }
        public PesadasDetalle(int ID, int pesadaID,int TipoArrozId, decimal kilos, decimal cantidadDeSacos)
        {
            this.PesadaDetalleID = ID;
            this.PesadasID = pesadaID;
            this.TipoArrozID = TipoArrozId;
            Kilos = kilos;
            CantidadDeSacos = cantidadDeSacos;
        }
    }
}
