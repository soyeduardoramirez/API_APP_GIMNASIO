using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unach.Entrenador.Core.Models
{
    public class UsuariosResponse : SimpleResponse
    {
        //public int id { get; set; }
        public int idusuario { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        
    }
}
