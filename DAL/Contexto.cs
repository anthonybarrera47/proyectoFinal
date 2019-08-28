using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Factoria> Factorias { get; set; }
        public DbSet<TipoArroz> TiposArroz { get; set; }
        public DbSet<Productores> Productores { get; set; }
        public DbSet<Pesadas> Pesadas { get; set; }
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<PesadasDetalle> PesadaDetalle { get; set; }
        public Contexto() : base("ConStr")
        { }
    }
}
