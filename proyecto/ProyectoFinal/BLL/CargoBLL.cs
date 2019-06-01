using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using System.Data.Entity;
using System.Linq.Expressions;

namespace ProyectoFinal.BLL
{
    public class CargoBLL
    {
        public static bool Guardar(Cargos cargos)

        {
            bool paso = false;
            Contexto db = new Contexto();
            try

            {
                if (db.Cargo.Add(cargos) != null)
                    paso = db.SaveChanges() > 0;
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
        public static bool Modificar(Cargos cargo)

        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try

            {
                contexto.Entry(cargo).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)

                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)

            {
                throw;
            }
            return paso;
        }
        public static bool Eliminar(int id)

        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try

            {
                Cargos cargo = contexto.Cargo.Find(id);
                contexto.Cargo.Remove(cargo);

                if (contexto.SaveChanges() > 0)

                {
                    paso = true;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static Cargos Buscar(int id)

        {
            Contexto contexto = new Contexto();
            Cargos Cargo = new Cargos();
            try

            {
                Cargo = contexto.Cargo.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Cargo;
        }
        public static List<Cargos> GetList(Expression<Func<Cargos, bool>> Cargo)

        {
            List<Cargos> Lista = new List<Cargos>();
            Contexto db = new Contexto();
            try

            {

                Lista = db.Cargo.Where(Cargo).ToList();
            }

            catch (Exception)

            {
                throw;
            }

            finally

            {

                db.Dispose();
            }

            return Lista;
        }
    }
    }
