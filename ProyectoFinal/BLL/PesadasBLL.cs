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
        private static Usuario usuario = new Usuario();

        public static bool Guardar(Pesadas pesadas)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if(db.pesadas.Add(pesadas)!=null)
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
                if(db.pesadaDetalle.Add(pesadasDetalle)!=null)
                {
                    db.SaveChanges();
                    paso = true;
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
                var pesadaDetalle = Buscar(pesadas.PesadasId);
                foreach(var item in pesadas.PesadasDetalles)
                {
                    if (item.Id == 0)
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
                {
                    if (db.SaveChanges() > 0)
                        paso = true;
                }
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
                var Eliminar = db.pesadas.Find(Id);
                if(Eliminar!=null)
                {
                    db.pesadaDetalle.RemoveRange(db.pesadaDetalle.Where(x => x.PesadasId == Eliminar.PesadasId));
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
                pesadas = db.pesadas.Find(Id);
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
                pesada = db.pesadas.Where(pesadas).ToList();
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
        public static Usuario GetUsuario()
        {
            return usuario;
        }
    }
}
