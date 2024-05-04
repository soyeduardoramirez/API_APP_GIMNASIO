using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unach.Entrenador.Core.BL.Interfaces
{
    public interface IProgresos
    {
        Task<List<Models.ProgresosResponse>> ListadoProgresos();
    }
}
