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
    public class ProductoresBLL
    {
        public static bool Guardar(Productores productores)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                if (db.Productores.Add(productores) != null)
                {
                    db.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public static bool Modificar(Productores productores)
        {
            Contexto db = new Contexto();
            bool paso = true;
            try
            {
                db.Entry(productores).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = true;
            try
            {
                Productores productores = db.Productores.Find(id);
                db.Productores.Remove(productores);
                if (db.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public static Productores Buscar(int id)
        {
            Contexto db = new Contexto();
            Productores productores = new Productores();
            try
            {
                productores = db.Productores.Find(id);
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return productores;
        }
        public static List<Productores> GetList(Expression<Func<Productores, bool>> expression)
        {
            Contexto db = new Contexto();
            List<Productores> productores = new List<Productores>();
            try
            {
                productores = db.Productores.Where(expression).ToList();
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return productores;
        }
    }
}
