using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Rol.Query.VerRol
{
    public class VerRolQueryDTO
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public Permiso[] Permisos { get; set; }
    }

    public class Permiso
    {
        public int IdRuta { get; set; }
        public string Ruta { get; set; }
        public bool IsPermiso { get; set; }
    }
}
