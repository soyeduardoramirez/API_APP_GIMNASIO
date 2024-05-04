using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unach.Entrenador.Core.Models;

namespace Unach.Entrenador.Core.BL.Interfaces
{
    public interface IUsuarios
    {
        Task<List<Models.UsuariosResponse>> ListadoUsuarios();
        //Task<SimpleResponse> ListadoUsuarios();
        Task<SimpleResponse> AgregarUsuarios(Models.UsuariosResponse usuariosResponse);
        Task<SimpleResponse> ActualizarUsuarios(Models.UsuariosResponse usuariosResponse);
        Task<SimpleResponse> EliminarUsuarios(int idusuario);
        Task<List<Models.UsuariosResponse>> LLamarUsuarios(int idusuario);
        Task<SimpleResponse> HacerLogin(Models.UsuariosResponse usuariosResponse);
    }
}
