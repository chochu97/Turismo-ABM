using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EntradaDAO
    {
        public void GuardarEntrada(Entrada entrada)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TurismoDB"].ConnectionString);

            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = "INSERT INTO Entradas (id_tipoturismo, dni, monto, fecha_registro, fecha_validez) VALUES (@id_tipoturismo, @dni, @monto, @fecha_registro, @fecha_validez)";

                    using (SqlCommand comando = new SqlCommand(query, connection))
                    {
                        comando.Parameters.AddWithValue("@id_tipoturismo", entrada.id_tipoturismo);
                        comando.Parameters.AddWithValue("@dni", entrada.dni);
                        comando.Parameters.AddWithValue("@monto", entrada.monto);
                        comando.Parameters.AddWithValue("@fecha_registro", DateTime.Now);
                        comando.Parameters.AddWithValue("@fecha_validez", entrada.fecha_validez);

                        comando.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEntrada( int id)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TurismoDB"].ConnectionString);

            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = "DELETE FROM Entradas WHERE id_entrada = @id_entrada";
                    using(SqlCommand comando = new SqlCommand(query, connection))
                    {
                        comando.Parameters.AddWithValue("@id_entrada", id);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarEntrada(int id, DateTime fecha) 
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TurismoDB"].ConnectionString);

            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = "UPDATE Entradas SET fecha_validez = @fecha_validez WHERE id_entrada = @id_entrada";

                    using(SqlCommand comando = new SqlCommand(query, connection))
                    {
                        comando.Parameters.AddWithValue("@id_entrada", id);
                        comando.Parameters.AddWithValue("@fecha_validez", fecha);
                        comando.ExecuteNonQuery();
                    }

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Entrada> GetEntradaList()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TurismoDB"].ConnectionString);

            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = "SELECT * FROM Entradas";

                    using(SqlCommand comando = new SqlCommand(query, connection))
                    {
                        using(SqlDataReader reader = comando.ExecuteReader())
                        {
                            List<Entrada> entradas = new List<Entrada>();

                            while(reader.Read())
                            {
                                Entrada ticket = new Entrada();
                                ticket.id_entrada = Convert.ToInt32(reader["id_entrada"]);
                                ticket.id_tipoturismo = Convert.ToInt32(reader["id_tipoturismo"]);
                                ticket.dni = Convert.ToInt32(reader["dni"]);
                                ticket.monto = Convert.ToDouble(reader["monto"]);
                                ticket.fecha_registro = Convert.ToDateTime(reader["fecha_registro"]);
                                ticket.fecha_validez = Convert.ToDateTime(reader["fecha_validez"]);

                                entradas.Add(ticket);
                            }

                            return entradas;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
