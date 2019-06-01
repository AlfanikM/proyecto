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
    public class UsuarioBLL
    {
        public static bool Guardar(Usuarios usuario)

        {
            bool paso = false;
            Contexto db = new Contexto();

            try

            {
              if(db.Usuario.Add(usuario) != null)
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
        public static bool Modificar(Usuarios usuario)

        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try

            {

                contexto.Entry(usuario).State = EntityState.Modified;

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

                Usuarios usuario = contexto.Usuario.Find(id);



                contexto.Usuario.Remove(usuario);



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
        public static Usuarios Buscar(int id)

        {

            Contexto contexto = new Contexto();

            Usuarios usuario = new Usuarios();

            try

            {

                usuario = contexto.Usuario.Find(id);

                contexto.Dispose();

            }

            catch (Exception)

            {

                throw;

            }

            return usuario;

        }
        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> usuario)

        {

            List<Usuarios> Lista = new List<Usuarios>();

            Contexto db = new Contexto();

            try

            {

                Lista = db.Usuario.Where(usuario).ToList();

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
