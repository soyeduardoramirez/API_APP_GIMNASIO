using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unach.Entrenador.Core.Models
{
    public class SimpleResponse
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public string Clave { get; set; }
    }
}