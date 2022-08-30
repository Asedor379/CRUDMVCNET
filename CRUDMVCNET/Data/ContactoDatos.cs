using CRUDMVCNET.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDMVCNET.Data
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            var ObjetoLista = new List<ContactoModel>();

            var conectar = new Conexion();

            using (var Conector = new SqlConnection(conectar.getCadenaSQL()))
            {
                Conector.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", Conector);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObjetoLista.Add(new ContactoModel()
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["telefono"].ToString(),
                            Correo = dr["correo"].ToString()
                        });
                    }
                }
            }
            return ObjetoLista;

        }

        public ContactoModel Obtener(int IdContacto)
        {
            var oContacto = new ContactoModel();

            var cn = new Conexion();

            using (var Conector = new SqlConnection(cn.getCadenaSQL()))
            {

                Conector.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener", Conector);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["telefono"].ToString();
                        oContacto.Correo = dr["correo"].ToString();


                    }
                }
            }
            return oContacto;
        }
        public bool Guardar(ContactoModel ocontacto)
        {
            bool respuesta;

            try
            {

                var cn = new Conexion();

                using (var Conector = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conector.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardar", Conector);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Editar(ContactoModel ocontacto)
        {
            bool respuesta;

            try
            {

                var cn = new Conexion();

                using (var Conector = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conector.Open();
                    SqlCommand cmd = new SqlCommand("sp_editar", Conector);
                    cmd.Parameters.AddWithValue("IdContacto", ocontacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }



        public bool Eliminar(int IdContacto)
        {
            bool respuesta;

            try
            {

                var cn = new Conexion();

                using (var Conector = new SqlConnection(cn.getCadenaSQL()))
                {

                    Conector.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminar", Conector);
                    cmd.Parameters.AddWithValue("IdContacto",IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

    }
}
