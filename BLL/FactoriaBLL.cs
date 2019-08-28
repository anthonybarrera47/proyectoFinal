using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FactoriaBLL
    {
        public static bool Guardar(Factoria factoria)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                if (db.Factorias.Add(factoria) != null)
                {
                    db.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Factoria factoria)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                db.Entry(factoria).State = System.Data.Entity.EntityState.Modified;
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
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                Factoria factoria = db.Factorias.Find(id);
                db.Factorias.Remove(factoria);
                if (db.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public static Factoria Buscar(int id)
        {
            Contexto db = new Contexto();
            Factoria factoria = new Factoria();
            try
            {
                factoria = db.Factorias.Find(id);
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return factoria;
        }
        public static List<Factoria> GetList(Expression<Func<Factoria, bool>> expression)
        {
            List<Factoria> factorias = new List<Factoria>();
            Contexto db = new Contexto();
            try
            {
                factorias = db.Factorias.Where(expression).ToList();
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return factorias;
        }
    }
}
