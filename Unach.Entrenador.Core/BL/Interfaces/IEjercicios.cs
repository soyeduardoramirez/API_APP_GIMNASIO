using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unach.Entrenador.Core.Models;

namespace Unach.Entrenador.Core.BL.Interfaces
{
    public interface IEjercicios
    {
        Task<List<Models.EjerciciosResponse>> ListadoEjercicios();
        Task<List<Models.EjerciciosResponse>> LLamarEjercicios(int idejercicio);
        Task<List<Models.EjerciciosResponse>> LLamarEjerciciosRelacionados(int idejercicio);
    }
}
