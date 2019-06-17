﻿using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProyectoFinal.BLL
{
    public class PesadaDetalleBLL
    {
        public static PesadasDetalle Buscar(int Id)
        {
            PesadasDetalle pesadaDetalle = new PesadasDetalle();
            Contexto db = new Contexto();
            try
            {
                pesadaDetalle = db.PesadaDetalle.Find(Id);
            }catch(Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return pesadaDetalle;
        }
        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var Eliminar = db.PesadaDetalle.Find(Id);
                if (Eliminar != null)
                {
                    db.Entry(Eliminar).State = System.Data.Entity.EntityState.Deleted;
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
        public static PesadasDetalle BuscarElemento(List<PesadasDetalle> lista,int ID)
        {
            PesadasDetalle pDetalle = new PesadasDetalle();


        }
        public static List<PesadasDetalle> GetList(Expression<Func<PesadasDetalle,bool>>pesadas)
        {
            List<PesadasDetalle> pesadasDetalles = new List<PesadasDetalle>();
            Contexto db = new Contexto();
            try
            {
                pesadasDetalles = db.PesadaDetalle.Where(pesadas).ToList();
            }catch(Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return pesadasDetalles;
        }
    }
    
}
