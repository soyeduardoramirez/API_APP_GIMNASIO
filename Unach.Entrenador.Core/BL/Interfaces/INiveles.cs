using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unach.Entrenador.Core.Models;

namespace Unach.Entrenador.Core.BL.Interfaces
{
    public interface INiveles
    {

        
        Task<List<Models.NivelesResponse>> ListadoNiveles();
        Task<SimpleResponse> AgregarNiveles(Models.NivelesResponse nivelesResponse);
        Task<SimpleResponse> ActualizarNiveles(Models.NivelesResponse nivelesResponse);
        Task<SimpleResponse> EliminarNiveles(int idnivel);
        Task<List<Models.NivelesResponse>> LLamarNiveles(int idnivel);

    }
}
