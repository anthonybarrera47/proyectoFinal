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
        public static bool Guardar(TiposArroz tiposArroz)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                if (db.tiposArroz.Add(tiposArroz) != null)
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
        public static bool Modificar(TiposArroz tiposArroz)
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
                TiposArroz tiposArroz = db.tiposArroz.Find(id);
                db.tiposArroz.Remove(tiposArroz);
                if (db.SaveChanges() > 0)
                    paso = true;
            }catch(Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public static TiposArroz Buscar(int id)
        {
            Contexto db = new Contexto();
            TiposArroz tiposArroz = new TiposArroz();
            try
            {
                 tiposArroz = db.tiposArroz.Find(id);
            }catch(Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return tiposArroz;
        }
        public static List<TiposArroz> GetList(Expression<Func<TiposArroz,bool>>expression)
        {
            Contexto db = new Contexto();
            List<TiposArroz> tiposArroz = new List<TiposArroz>();
            try
            {
                tiposArroz = db.tiposArroz.Where(expression).ToList();
            }catch(Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return tiposArroz;
        }
    }
}
