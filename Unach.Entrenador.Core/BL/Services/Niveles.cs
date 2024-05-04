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
    public class Niveles : INiveles
    {

        public async Task<SimpleResponse> ActualizarNiveles(NivelesResponse nivelesResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_niveles]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "Actualizar");
                sqlCommand.Parameters.AddWithValue("@idnivel", nivelesResponse.idnivel);
                sqlCommand.Parameters.AddWithValue("@tiponivel", nivelesResponse.tiponivel);
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
                        Resultado.Exito = 0;
                        Resultado.Mensaje = "Actualizado Correctamente";


                    }
                }

                conexion.Close();
                Resultado.Exito = (int)exito.Value;
                Resultado.Mensaje = msg.Value.ToString();

                return Resultado;

            }
        }
        public async Task<SimpleResponse> AgregarNiveles(NivelesResponse nivelesResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_niveles]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "Insertar");
                sqlCommand.Parameters.AddWithValue("@idnivel", nivelesResponse.idnivel);
                sqlCommand.Parameters.AddWithValue("@tiponivel", nivelesResponse.tiponivel);

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
                        Resultado.Exito = 0;
                        Resultado.Mensaje = "Insertado Correctamente";


                    }
                }

                conexion.Close();
                Resultado.Exito = (int)exito.Value;
                Resultado.Mensaje = msg.Value.ToString();

                return Resultado;

            }
        }

        public async Task<SimpleResponse> EliminarNiveles(int idnivel)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_niveles]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "Eliminar");
                sqlCommand.Parameters.AddWithValue("@idnivel", idnivel);

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
                        Resultado.Exito = 0;
                        Resultado.Mensaje = "Borrado Correctamente";


                    }
                }

                conexion.Close();
                Resultado.Exito = (int)exito.Value;
                Resultado.Mensaje = msg.Value.ToString();

                return Resultado;

            }
        }
        public async Task<List<NivelesResponse>> LLamarNiveles(int idnivel)
        {
            List<NivelesResponse> Resultado = new List<NivelesResponse>();
            //SimpleResponse res = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_niveles]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@opcion", "LLamar");
                sqlCommand.Parameters.AddWithValue("@idnivel", idnivel);

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
                        new Models.NivelesResponse()
                        {
                            idnivel = lectura.GetInt32(0),
                            tiponivel = lectura.GetString(1),

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
        public async Task<List<NivelesResponse>> ListadoNiveles()


        {
            List<NivelesResponse> Resultado = new List<NivelesResponse>();

            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_niveles]";
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
                            new Models.NivelesResponse()
                            {
                                //id = lectura.GetGuid(0),
                                idnivel = lectura.GetInt32(0),
                                tiponivel = lectura.GetString(1),
                            });
                    }

                }

                conexion.Close();
                return Resultado;

            }

        }
    

    }
}

