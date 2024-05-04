using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unach.Entrenador.API.Controllers
{
    [ApiController]
    [Route("Api/Planes")]
    public class PlanesController : ControllerBase
    {
        readonly Core.BL.Interfaces.IPlanes _planesService;

        public PlanesController (Core.BL.Interfaces.IPlanes planes)
        {
            this._planesService = planes;
        }

        [HttpGet("ObtenerPlanes")]
        public async Task<IActionResult> ListadoPlanes()
        {
            var Resultado = await this._planesService.ListadoPlanes();

            return Ok(Resultado);
        }

    }
}
