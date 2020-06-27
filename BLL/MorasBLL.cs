using Microsoft.EntityFrameworkCore;
using PrestamosWPF.DAL;
using PrestamosWPF.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PrestamosWPF.BLL
{
    class MorasBLL
    {
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
               
                var Mora = contexto.Moras.Find(id);
                if (Mora != null)
                {
                    contexto.Moras.Remove(Mora);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Moras Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Moras Mora;

            try
            {
                Mora = contexto.Moras.Include(x => x.MoraDetalle).Where(p => p.MoraId == Id).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            contexto.Dispose();
            return Mora;


        }
        public static bool Guardar(Moras Mora)
        {
            if (!Existe(Mora.MoraId))
                return Insertar(Mora);
            else
                return Modificar(Mora);
        }
        public static bool Modificar(Moras Mora)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete From MorasDetalle where MoraId = {Mora.MoraId}");
                foreach (var anterior in Mora.MoraDetalle)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                contexto.Entry(Mora).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Insertar(Moras Mora)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                
                contexto.Moras.Add(Mora);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        public static List<Moras> GetList(Expression<Func<Moras, bool>> expresion)
        {
            Contexto contexto = new Contexto();
            List<Moras> lista = new List<Moras>();
            try
            {
                lista = contexto.Moras.Where(expresion).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            contexto.Dispose();
            return lista;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Moras
                .Any(e => e.MoraId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado; //si
        }
    }
}
