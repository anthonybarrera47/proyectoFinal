using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PesadasBLL
    {
        private static readonly Usuarios Usuario = new Usuarios();

        public static bool Guardar(Pesadas pesadas)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Pesadas.Add(pesadas) != null)
                    paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public static bool Modificar(Pesadas pesadas)
        {
            bool paso = false;
            var Anterior = Buscar(pesadas.PesadaID);
            Contexto db = new Contexto();
            try
            {
                foreach (var item in Anterior.PesadasDetalles)
                {
                    var Kilos = db.TiposArroz.Find(item.TipoArrozID);
                    if (!pesadas.PesadasDetalles.Exists(d => d.PesadaDetalleID == item.PesadaDetalleID))
                    {
                        Kilos.Kilos -= item.Kilos;
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }
                foreach (var item in pesadas.PesadasDetalles)
                {
                    var estado = System.Data.Entity.EntityState.Unchanged;
                    if (item.PesadaDetalleID == 0)
                    {
                        var Kilos = db.TiposArroz.Find(item.TipoArrozID);
                        Kilos.Kilos += item.Kilos;
                        estado = EntityState.Added;
                    }
                    else
                    {
                        var AnteriorDetalle = PesadaDetalleBLL.Buscar(item.PesadaDetalleID);
                        var Kilos = db.TiposArroz.Find(item.TipoArrozID);
                        Kilos.Kilos -= AnteriorDetalle.Kilos;
                        Kilos.Kilos += item.Kilos;
                        estado = EntityState.Modified;
                    }
                    db.Entry(item).State = estado;
                }
                db.Entry(pesadas).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;

        }
        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var Eliminar = db.Pesadas.Find(Id);
                if (Eliminar != null)
                {
                    db.PesadaDetalle.RemoveRange(db.PesadaDetalle.Where(x => x.PesadasID == Eliminar.PesadaID));
                    db.Entry(Eliminar).State = EntityState.Deleted;
                    if (db.SaveChanges() > 0)
                        paso = true;
                }

            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public static Pesadas Buscar(int Id)
        {
            Pesadas pesadas = new Pesadas();
            Contexto db = new Contexto();
            try
            {
                pesadas = db.Pesadas.Find(Id);
                if (pesadas != null)
                {
                    pesadas.PesadasDetalles.Count();
                }
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return pesadas;
        }
        public static List<Pesadas> GetList(Expression<Func<Pesadas, bool>> pesadas)
        {
            List<Pesadas> pesada = new List<Pesadas>();
            Contexto db = new Contexto();
            try
            {
                pesada = db.Pesadas.Where(pesadas).ToList();
                foreach (var item in pesada)
                {
                    item.PesadasDetalles.Count();
                }
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return pesada;
        }
        public static void EnviarKilaje(List<PesadasDetalle> detalle)
        {
            foreach (var item in detalle)
            {
                TipoArroz kilaje = TipoArrozBLL.Buscar(item.TipoArrozID);
                kilaje.Kilos += item.Kilos;
                TipoArrozBLL.Modificar(kilaje);
            }
        }
        public static void ArreglarDetalle(Pesadas pesada)
        {
            foreach (var item in pesada.PesadasDetalles)
            {
                var tipoArroz = TipoArrozBLL.Buscar(item.TipoArrozID);
                tipoArroz.Kilos -= item.Kilos;
                TipoArrozBLL.Modificar(tipoArroz);
            }
        }
        public static void UsuarioParaLogin(String Nombre, int id)
        {
            Usuario.Nombre = Nombre;
            Usuario.UsuarioID = id;
        }
        public static Usuarios GetUsuario()
        {
            return Usuario;
        }
    }
}
