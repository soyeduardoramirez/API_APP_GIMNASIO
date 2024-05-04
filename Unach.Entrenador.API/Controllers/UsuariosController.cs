using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unach.Entrenador.API.Controllers
{
    [ApiController]
    [Route("Api/Usuarios")]
    public class UsuariosController : ControllerBase
    {
        readonly Core.BL.Interfaces.IUsuarios _usuariosService;

        public UsuariosController(Core.BL.Interfaces.IUsuarios usuarios)
        {
            this._usuariosService = usuarios;
        }

        [HttpGet("ObtenerUsuarios")]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            var Resultado = await this._usuariosService.ListadoUsuarios();
            return Ok(Resultado);
        }

        [HttpPost("AgregarUsuario")]
        public async Task<IActionResult> AgregarUsuario(Core.Models.UsuariosResponse usuariosResponse)
        {
            var Resultado = await this._usuariosService.AgregarUsuarios(usuariosResponse);
            return Ok(Resultado);
        }
        [HttpPut("ActualizarUsuario")]
        public async Task<IActionResult> ActualizarUsuario(Core.Models.UsuariosResponse usuariosResponse)
        {
            var Resultado = await this._usuariosService.ActualizarUsuarios(usuariosResponse);
            return Ok(Resultado);
        }
        [HttpDelete("Eliminar")]
        public async Task<IActionResult> EliminarUsuarios(int idusuario)
        {
            var Resultado = await this._usuariosService.EliminarUsuarios(idusuario);
            return Ok(Resultado);
        }
        [HttpGet("LlamarUsuario")]
        public async Task<IActionResult> LlamarUsuarios(int idusuario)
        {
            var Resultado = await this._usuariosService.LLamarUsuarios(idusuario);
            return Ok(Resultado);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> HacerLogin(Core.Models.UsuariosResponse usuarioResponse)
        {
            var Resultado = await this._usuariosService.HacerLogin(usuarioResponse);
            return Ok(Resultado);
        }
    }
}