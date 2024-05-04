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
    public class Enfoques : IEnfoques

    {

        public async Task<SimpleResponse> AgregarEnfoques(EnfoquesResponse enfoquesResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_enfoques]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "Insertar");
                sqlCommand.Parameters.AddWithValue("@idenfoque", enfoquesResponse.idenfoque);
                sqlCommand.Parameters.AddWithValue("@tipoenfoque", enfoquesResponse.tipoenfoque);
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


        public async Task<SimpleResponse> ActualizarEnfoques(EnfoquesResponse enfoquesResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                /*         public int idenfoques { get; set; }
        //public int idplan { get; set; }
        
        public string tipoenfoque{ get; set; } */
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_enfoques]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "Actualizar");
                //sqlCommand.Parameters.AddWithValue("@id", usuariosResponse.id);
                sqlCommand.Parameters.AddWithValue("@idenfoque", enfoquesResponse.idenfoque);
                sqlCommand.Parameters.AddWithValue("@tipoenfoque", enfoquesResponse.tipoenfoque);
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

        public async Task<SimpleResponse> EliminarEnfoques(int idenfoque)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_enfoques]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "Eliminar");
                sqlCommand.Parameters.AddWithValue("@idenfoque", idenfoque);

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


        public async Task<List<EnfoquesResponse>> LLamarEnfoques(int idenfoque)
        {
            List<EnfoquesResponse> Resultado = new List<EnfoquesResponse>();
            //SimpleResponse res = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_enfoques]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@opcion", "LLamar");
                sqlCommand.Parameters.AddWithValue("@idenfoque", idenfoque);

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
                        new Models.EnfoquesResponse()
                        {
                            //id = lectura.GetGuid(0),
                            idenfoque = lectura.GetInt32(0),
                            tipoenfoque = lectura.GetString(1),
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

        
        public async Task<List<EnfoquesResponse>> ListadoEnfoques()

        {
            List<EnfoquesResponse> Resultado = new List<EnfoquesResponse>();

            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_enfoques]";
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
                            new Models.EnfoquesResponse()
                            {
                                //id = lectura.GetGuid(0),
                                idenfoque = lectura.GetInt32(0),
                                tipoenfoque = lectura.GetString(1)
                            });
                    }

                }

                conexion.Close();
                return Resultado;

            }

        }
        
       
        
    }
}
