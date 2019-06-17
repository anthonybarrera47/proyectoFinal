using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BLL
{
    public class PesadasBLL
    {
        private static Usuarios Usuario = new Usuarios();

        public static bool Guardar(Pesadas pesadas)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if(db.Pesadas.Add(pesadas)!=null)
                {
                    db.SaveChanges();
                    paso = true;
                }
            }catch(Exception)
            { throw;}
            finally
            { db.Dispose(); }
            return paso;
        }
        public static bool GuardarDetalle(PesadasDetalle pesadasDetalle)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if(db.PesadaDetalle.Add(pesadasDetalle)!=null)
                {
                    paso = db.SaveChanges() >0 ;
                }
            }catch(Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public static bool Modificar(Pesadas pesadas)
        {
            bool paso = false;
            bool pas = false;
            Contexto db = new Contexto();
            try
            {
                var pesadaDetalle = Buscar(pesadas.PesadaID);
                db.Entry(pesadas).State = EntityState.Modified;
                ArreglarDetalle(pesadaDetalle);
                foreach (var item in pesadas.PesadasDetalles)
                {
                    if (item.PesadaDetalleID == 0)
                        GuardarDetalle(item);
                    else
                    {
                        db.Entry(item).State = EntityState.Modified;
                        if(db.SaveChanges()>0)
                        {
                            paso = true;
                            pas = true;
                        }
                    }
                }
                if(pas == false)
                    paso = (db.SaveChanges() > 0);
              
                EnviarKilaje(Buscar(pesadas.PesadaID).PesadasDetalles);
            }catch(Exception)
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
                if(Eliminar!=null)
                {
                    db.PesadaDetalle.RemoveRange(db.PesadaDetalle.Where(x => x.PesadasID == Eliminar.PesadaID));
                    db.Entry(Eliminar).State = EntityState.Deleted;
                    if (db.SaveChanges() > 0)
                        paso = true;
                }

            }catch(Exception)
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
                if(pesadas!=null)
                {
                    pesadas.PesadasDetalles.Count();
                }
            }catch(Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return pesadas;
        }
        public static List<Pesadas> GetList(Expression<Func<Pesadas,bool>> pesadas)
        {
            List<Pesadas> pesada = new List<Pesadas>();
            Contexto db = new Contexto();
            try
            {
                pesada = db.Pesadas.Where(pesadas).ToList();
                foreach(var item in pesada)
                {
                    item.PesadasDetalles.Count();
                }
            }catch(Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return pesada;
        }
        public static void EnviarKilaje(List<PesadasDetalle> detalle)
        {
            foreach(var item in detalle)
            {
                TipoArroz kilaje = TipoArrozBLL.Buscar(item.TipoArrozID);
                kilaje.Kilos += item.Kilos;
                TipoArrozBLL.Modificar(kilaje);
            }
        }
        public static void DescontarKilaje(List<PesadasDetalle> detalle)
        {
            foreach(var item in detalle)
            {
                var kilaje = TipoArrozBLL.Buscar(item.TipoArrozID);
                kilaje.Kilos -= item.Kilos;
                TipoArrozBLL.Modificar(kilaje);
            }
        }
        public static void ArreglarDetalle(Pesadas pesada)
        {
            foreach(var item in pesada.PesadasDetalles)
            {
                var tipoArroz = TipoArrozBLL.Buscar(item.TipoArrozID);
                tipoArroz.Kilos -= item.Kilos;
                TipoArrozBLL.Modificar(tipoArroz);
            }
        }
        public static List<PesadasDetalle> Editar(List<PesadasDetalle> list,PesadasDetalle detalle)
        {
            foreach(var item in list)
            {
                if (item.PesadaDetalleID == detalle.PesadaDetalleID)
                {
                    item.Kilos = detalle.Kilos;
                    item.CantidadDeSacos = detalle.CantidadDeSacos;
                }   
            }
            return list;
        }
        public static void UsuarioParaLogin(String Nombre,int id)
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
