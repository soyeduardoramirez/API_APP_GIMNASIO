using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unach.Entrenador.Core.Models;

namespace Unach.Entrenador.Core.BL.Interfaces
{
    public interface IPlanes
    {
        
        Task<List<Models.PlanesResponse>> ListadoPlanes();
    }
}
