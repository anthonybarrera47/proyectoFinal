using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Factoria> factorias { get; set; }
        public DbSet<TiposArroz> tiposArroz { get; set; }
        public DbSet<Productores> productores { get; set; }
        public DbSet<Pesadas> pesadas { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<PesadasDetalle> pesadaDetalle { get; set; }

        public Contexto() : base("ConStr")
        { }
    }
}
