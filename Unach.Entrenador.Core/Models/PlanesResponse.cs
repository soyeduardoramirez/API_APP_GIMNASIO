using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unach.Entrenador.Core.Models
{
    public class PlanesResponse : SimpleResponse
    {
        public int idplan { get; set; }
        public string nombreplanes  { get; set; }
        public string descripcion { get; set; }
    }
}
