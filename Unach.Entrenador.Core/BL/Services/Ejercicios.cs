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
    public class Ejercicios : IEjercicios
    {
     


        public async Task<List<EjerciciosResponse>> LLamarEjercicios(int idejercicio)
        {
            List<EjerciciosResponse> Resultado = new List<EjerciciosResponse>();
            //SimpleResponse res = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {

                
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_ejercicios]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@opcion", "LLamar");
                sqlCommand.Parameters.AddWithValue("@idejercicio", idejercicio);

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
                        new Models.EjerciciosResponse()
                        {
                            //id = lectura.GetGuid(0),
                            idejercicio = lectura.GetInt32(0),
                            tipoejercicio = lectura.GetString(1),
                            descripcion = lectura.GetString(2),
                            //Exito=0,
                            //Mensaje=""
                        });


                        //res.Exito = 0; 
                        //res.Mensaje = "";
                    }
                }

                conexion.Close();
                //res.Exito = (int)exito.Value;
                //res.Mensaje = msg.Value.ToString();
                return Resultado;
            }
        }


        public async Task<List<EjerciciosResponse>> ListadoEjercicios()

        {
            List<EjerciciosResponse> Resultado = new List<EjerciciosResponse>();

            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_ejercicios]";
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
                            new Models.EjerciciosResponse()
                            {
                                idejercicio = lectura.GetInt32(0),
                                tipoejercicio = lectura.GetString(1),
                                descripcion = lectura.GetString(2),
                            });
                    }

                }

                conexion.Close();
                return Resultado;

            }

        }
        public async Task<List<EjerciciosResponse>> LLamarEjerciciosRelacionados(int idejercicio)
        {
            List<EjerciciosResponse> Resultado = new List<EjerciciosResponse>();
            //SimpleResponse res = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {


                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_ejercicios]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@opcion", "LLamar");
                sqlCommand.Parameters.AddWithValue("@idejercicio", idejercicio);

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
                        new Models.EjerciciosResponse()
                        {
                            //id = lectura.GetGuid(0),
                            idejercicio = lectura.GetInt32(0),
                            tipoejercicio = lectura.GetString(1),
                            descripcion = lectura.GetString(2),
                            series = lectura.GetString(3),
                            repeticiones = lectura.GetString(4),
                            //Exito=0,
                            //Mensaje=""
                        });


                        //res.Exito = 0; 
                        //res.Mensaje = "";
                    }
                }

                conexion.Close();
                //res.Exito = (int)exito.Value;
                //res.Mensaje = msg.Value.ToString();
                return Resultado;
            }
        }
    }
}