using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unach.Entrenador.Core.BL.Interfaces;
using Unach.Entrenador.Core.Models;

namespace Unach.Entrenador.Core.BL.Services
{
    public class Planes : IPlanes
    {
        public async Task<List<Models.PlanesResponse>> ListadoPlanes()
        {
            List<Models.PlanesResponse> Resultado = new List<Models.PlanesResponse>();

            using (var conexion= new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_planes]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Opcion", "Listado");

                var lectura = await sqlCommand.ExecuteReaderAsync();
                if (lectura.HasRows)
                {
                    while (lectura.Read())
                    {
                        Resultado.Add(
                            new Models.PlanesResponse()
                            {
                                idplan = lectura.GetInt32(0),
                                nombreplanes=lectura.GetString(1),
                                descripcion=lectura.GetString(2),
                            });
                    }
                }

                conexion.Close();
                return Resultado;
            }
        }
    }
}
