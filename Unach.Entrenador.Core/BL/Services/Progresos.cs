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
    public class Progresos : IProgresos
    {
        
        public async Task<List<ProgresosResponse>> ListadoProgresos()

        {
            List<ProgresosResponse> Resultado = new List<ProgresosResponse>();

            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_progresos]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "Listado");


                #endregion
                #region Parametros de Salida
                SqlParameter exito = new SqlParameter();
                exito.ParameterName = "@Exito";
                exito.SqlDbType = System.Data.SqlDbType.Int;
                exito.Direction = System.Data.ParameterDirection.Output;
                sqlCommand.Parameters.Add(exito);

                SqlParameter msg = new SqlParameter();
                msg.ParameterName = "@Mensaje";
                msg.SqlDbType = System.Data.SqlDbType.VarChar;
                msg.Size = 250;
                msg.Direction = System.Data.ParameterDirection.Output;
                sqlCommand.Parameters.Add(msg);

                #endregion


                var lectura = await sqlCommand.ExecuteReaderAsync();
                if (lectura.HasRows)
                {
                    while (lectura.Read())
                    {
                        Resultado.Add(
                            new Models.ProgresosResponse()
                            {
                                idprogreso = lectura.GetInt32(0),
                                terminado = lectura.GetInt32(1),
                            });
                    }

                }

                conexion.Close();
                return Resultado;

            }

        }
    }
}
