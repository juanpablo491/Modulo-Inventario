using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int idusuario)
        {
            List<Permiso> lista = new List<Permiso>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT PERMISO.IdRol, PERMISO.NombreMenu FROM PERMISO");
                    query.AppendLine("INNER JOIN ROL ON PERMISO.IdRol = ROL.IdRol ");
                    query.AppendLine("INNER JOIN USUARIO ON ROL.IdRol = USUARIO.IdRol");
                    query.AppendLine("where USUARIO.IdUsuario = @idusuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idusuario", idusuario);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Permiso()
                            {
                                oRol = new Rol() {IdRol = Convert.ToInt32(reader["IdRol"]) },
                                NombreMenu = reader["NombreMenu"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();
                }
            }
            return lista;
        }
    }
}
