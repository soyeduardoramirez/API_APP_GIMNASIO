using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unach.Entrenador.API.Controllers
{
    [ApiController]
    [Route("Api/Ejercicios")]
    public class EjerciciosController : ControllerBase
    {
        readonly Core.BL.Interfaces.IEjercicios _ejerciciosService;

        public EjerciciosController(Core.BL.Interfaces.IEjercicios ejercicios)
        {
            this._ejerciciosService = ejercicios;
        }

        [HttpGet("ObtenerEjercicios")]
        public async Task<IActionResult> ListadoEjercicios()
        {
            var Resultado = await this._ejerciciosService.ListadoEjercicios();
            return Ok(Resultado);
        }

        [HttpGet("LlamarEjercicio")]
        public async Task<IActionResult> LlamarEjercicios(int idejercicio)
        {
            var Resultado = await this._ejerciciosService.LLamarEjercicios(idejercicio);
            return Ok(Resultado);
        }

        [HttpGet("LlamarEjerciciosRelacionados")]
        public async Task<IActionResult> LLamarEjerciciosRelacionados(int idejercicio)
        {
            var Resultado = await this._ejerciciosService.LLamarEjercicios(idejercicio);
            return Ok(Resultado);
        }
    }
}