using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unach.Entrenador.API.Controllers
{
    [ApiController]
    [Route("Api/Enfoques")]
    public class EnfoquesController : ControllerBase

    { /*
        readonly Core.BL.Interfaces.IEnfoques _enfoqueService;

        public EnfoquesController(Core.BL.Interfaces.IEnfoques Ienfoque)
        {
            this._enfoqueService = Ienfoque;
        }


        [HttpGet("ObtenerEnfoques")]
        public async Task<IActionResult> ObtenerEnfoques()
        {
            var Resultado = await this._enfoqueService.ObtenerListaEnfoques();
            return Ok(Resultado);
        }*/

        //aqui

        readonly Core.BL.Interfaces.IEnfoques _enfoquesService;

        public EnfoquesController(Core.BL.Interfaces.IEnfoques enfoques)
        {
            this._enfoquesService = enfoques;
        }

        [HttpGet("ObtenerEnfoques")]
        public async Task<IActionResult> ObtenerEnfoques()
        {
            var Resultado = await this._enfoquesService.ListadoEnfoques();
            return Ok(Resultado);
        }

        [HttpPost("AgregarEnfoque")]
        public async Task<IActionResult> AgregarEnfoque(Core.Models.EnfoquesResponse enfoques)
        {
            var Resultado = await this._enfoquesService.AgregarEnfoques(enfoques);
            return Ok(Resultado);
        }
        [HttpPut("ActualizarEnfoque")]
        public async Task<IActionResult> ActualizarEnfoques(Core.Models.EnfoquesResponse enfoques)
        {
            var Resultado = await this._enfoquesService.ActualizarEnfoques(enfoques);
            return Ok(Resultado);
        }
        [HttpDelete("Eliminar")]
        public async Task<IActionResult> EliminarEnfoques(int idenfoque)
        {
            var Resultado = await this._enfoquesService.EliminarEnfoques(idenfoque);
            return Ok(Resultado);
        }
        [HttpGet("LlamarEnfoque")]
        public async Task<IActionResult> LlamarEnfoques(int idenfoque)
        {
            var Resultado = await this._enfoquesService.LLamarEnfoques(idenfoque);
            return Ok(Resultado);
        }





    }
}
