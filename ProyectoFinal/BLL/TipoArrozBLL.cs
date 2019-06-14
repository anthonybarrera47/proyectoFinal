using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BLL
{
    public class TipoArrozBLL
    {
        public static bool Guardar(TipoArroz tiposArroz)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                if (db.TiposArroz.Add(tiposArroz) != null)
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
        public static bool Modificar(TipoArroz tiposArroz)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                db.Entry(tiposArroz).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                    paso = true;
            }catch(Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                TipoArroz tiposArroz = db.TiposArroz.Find(id);
                db.TiposArroz.Remove(tiposArroz);
                if (db.SaveChanges() > 0)
                    paso = true;
            }catch(Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public static TipoArroz Buscar(int id)
        {
            Contexto db = new Contexto();
            TipoArroz tiposArroz = new TipoArroz();
            try
            {
                 tiposArroz = db.TiposArroz.Find(id);
            }catch(Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return tiposArroz;
        }
        public static List<TipoArroz> GetList(Expression<Func<TipoArroz,bool>>expression)
        {
            Contexto db = new Contexto();
            List<TipoArroz> tiposArroz = new List<TipoArroz>();
            try
            {
                tiposArroz = db.TiposArroz.Where(expression).ToList();
            }catch(Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return tiposArroz;
        }
    }
}
