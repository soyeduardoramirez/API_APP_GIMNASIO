using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Unach.Entrenador.API.Controllers
{

    [ApiController]
    [Route("Api/Niveles")]
    public class NivelesController : ControllerBase

    { 



        readonly Core.BL.Interfaces.INiveles _nivelesService;

        public NivelesController(Core.BL.Interfaces.INiveles niveles)
        {
            this._nivelesService = niveles;
        }

        [HttpGet("ObtenerNiveles")]
        public async Task<IActionResult> OObtenerNiveles()
        {
            var Resultado = await this._nivelesService.ListadoNiveles();
            return Ok(Resultado);
        }


        [HttpPost("AgregarNivel")]
        public async Task<IActionResult> AgregarNivel(Core.Models.NivelesResponse nivelesResponse)
        {
            var Resultado = await this._nivelesService.AgregarNiveles(nivelesResponse);
            return Ok(Resultado);
        }
        [HttpPut("ActualizarNivel")]
        public async Task<IActionResult> ActualizarNivel(Core.Models.NivelesResponse nivelesResponse)
        {
            var Resultado = await this._nivelesService.ActualizarNiveles(nivelesResponse);
            return Ok(Resultado);
        }
        [HttpDelete("Eliminar")]
        public async Task<IActionResult> EliminarNiveles(int idnivel)
        {
            var Resultado = await this._nivelesService.EliminarNiveles(idnivel);
            return Ok(Resultado);
        }
        [HttpGet("LlamarNivel")]
        public async Task<IActionResult> LlamarNiveles(int idnivel)
        {
            var Resultado = await this._nivelesService.LLamarNiveles(idnivel);
            return Ok(Resultado);
        }

    }
}
