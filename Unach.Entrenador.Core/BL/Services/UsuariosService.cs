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
    public class UsuariosService : IUsuarios
    {
        public async Task<SimpleResponse> ActualizarUsuarios(UsuariosResponse usuariosResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_usuarios]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "Actualizar");
                //sqlCommand.Parameters.AddWithValue("@id", usuariosResponse.id);
                sqlCommand.Parameters.AddWithValue("@idusuario", usuariosResponse.idusuario);
                sqlCommand.Parameters.AddWithValue("@nombre", usuariosResponse.nombre);
                sqlCommand.Parameters.AddWithValue("@apellidos", usuariosResponse.apellidos);
                sqlCommand.Parameters.AddWithValue("@telefono", usuariosResponse.telefono);
                sqlCommand.Parameters.AddWithValue("@email", usuariosResponse.email);
                sqlCommand.Parameters.AddWithValue("@usuario", usuariosResponse.usuario);
                sqlCommand.Parameters.AddWithValue("@contrasena", usuariosResponse.contrasena);
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
        public async Task<SimpleResponse> AgregarUsuarios(UsuariosResponse usuariosResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_usuarios]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "Insertar");
                sqlCommand.Parameters.AddWithValue("@nombre", usuariosResponse.nombre);
                sqlCommand.Parameters.AddWithValue("@apellidos", usuariosResponse.apellidos);
                sqlCommand.Parameters.AddWithValue("@telefono", usuariosResponse.telefono);
                sqlCommand.Parameters.AddWithValue("@email", usuariosResponse.email);
                sqlCommand.Parameters.AddWithValue("@usuario", usuariosResponse.usuario);
                sqlCommand.Parameters.AddWithValue("@contrasena", usuariosResponse.contrasena);
                sqlCommand.Parameters.AddWithValue("@clave", usuariosResponse.Clave);
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
        public async Task<SimpleResponse> EliminarUsuarios(int idusuario)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_usuarios]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "Eliminar");
                sqlCommand.Parameters.AddWithValue("@idusuario", idusuario);

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
        public async Task<List<UsuariosResponse>> LLamarUsuarios(int idusuario)
        {
            List<UsuariosResponse> Resultado = new List<UsuariosResponse>();
            //SimpleResponse res = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_usuarios]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@opcion", "LLamar");
                sqlCommand.Parameters.AddWithValue("@idusuario", idusuario);

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
                            new Models.UsuariosResponse()
                            {
                                //id = lectura.GetGuid(0),
                                idusuario = lectura.GetInt32(0),
                                nombre = lectura.GetString(1),
                                apellidos = lectura.GetString(2),
                                telefono = lectura.GetString(3),
                                email = lectura.GetString(4),
                                usuario = lectura.GetString(5),
                                contrasena = lectura.GetString(6),
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
        public async Task<List<UsuariosResponse>> ListadoUsuarios()
        
        {
            List<UsuariosResponse> Resultado = new List<UsuariosResponse>();
          
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_usuarios]";
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
                            new Models.UsuariosResponse()
                            {
                                //id = lectura.GetGuid(0),
                                idusuario = lectura.GetInt32(0),
                                nombre = lectura.GetString(1),
                                apellidos = lectura.GetString(2),
                                telefono = lectura.GetString(3),
                                email = lectura.GetString(4),
                                usuario = lectura.GetString(5),
                                contrasena = lectura.GetString(6),
                    });   
            }
                
            }

                conexion.Close();
                return Resultado;

            }

        }
        public async Task<SimpleResponse> HacerLogin(UsuariosResponse usuariosResponse)
        {
            SimpleResponse Resultado = new SimpleResponse();
            using (var conexion = new SqlConnection(Helpes.ConfiguracionesEstaticas.CadenaConexion))
            {
                conexion.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conexion;
                sqlCommand.CommandText = "[dbo].[sp_tabla_usuarios]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #region parametros de Entradas
                sqlCommand.Parameters.AddWithValue("@opcion", "Login");

                sqlCommand.Parameters.AddWithValue("@usuario", usuariosResponse.usuario);
                sqlCommand.Parameters.AddWithValue("@contrasena", usuariosResponse.contrasena);
                sqlCommand.Parameters.AddWithValue("@clave", usuariosResponse.Clave);

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
                        Resultado.Mensaje = "Login Correctamente";


                    }
                }

                conexion.Close();
                Resultado.Exito = (int)exito.Value;
                Resultado.Mensaje = msg.Value.ToString();

                return Resultado;

            }
        }
    }
}

