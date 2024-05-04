using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unach.Entrenador.API.Controllers
{
    [ApiController]
    [Route("Api/Progresos")]
    public class ProgresosController : ControllerBase
    {
        readonly Core.BL.Interfaces.IProgresos _progresosService;

        public ProgresosController(Core.BL.Interfaces.IProgresos progresos)
        {
            this._progresosService = progresos;
        }

        [HttpGet("ObtenerProgresos")]
        public async Task<IActionResult> ListadoProgresos()
        {
            var Resultado = await this._progresosService.ListadoProgresos();

            return Ok(Resultado);
        }

    }
}
