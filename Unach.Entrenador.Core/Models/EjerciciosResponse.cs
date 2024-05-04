using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unach.Entrenador.Core.Models
{
    public class EjerciciosResponse : SimpleResponse
    {
        public int idejercicio { get; set; }
        public string tipoejercicio { get; set; }
        public string descripcion { get; set; }
        public string series { get; set; }
        public string repeticiones { get; set; }
    }
}
