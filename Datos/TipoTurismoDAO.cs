using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class TipoTurismoDAO
    {
        public List<TipoTurismo> GetTipoTurismos()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TurismoDB"].ConnectionString);

            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = "SELECT * FROM TipoTurismo";

                    using(SqlCommand comando = new SqlCommand(query, connection))
                    {
                        using(SqlDataReader reader = comando.ExecuteReader())
                        {
                            List<TipoTurismo> turismos = new List<TipoTurismo>();

                            while (reader.Read())
                            {
                                TipoTurismo turista = new TipoTurismo();
                                turista.id_tipoturismo = Convert.ToInt32(reader["id_tipoturismo"]);
                                turista.nombre = Convert.ToString(reader["nombre"]);

                                turismos.Add(turista);
                            }
                            return turismos;
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
