using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unach.Entrenador.Core.Models;

namespace Unach.Entrenador.Core.BL.Interfaces
{
    public interface IEnfoques
    {
        Task<List<Models.EnfoquesResponse>> ListadoEnfoques();
        Task<SimpleResponse> AgregarEnfoques(Models.EnfoquesResponse enfoquesResponse);
         Task<SimpleResponse> ActualizarEnfoques(Models.EnfoquesResponse enfoquesResponse);

    //  Task<List<Models.EnfoquesResponse>> ActualizarEnfoques();
        Task<SimpleResponse> EliminarEnfoques(int idenfoques);
        Task<List<Models.EnfoquesResponse>> LLamarEnfoques(int idenfoques);
    }
}
