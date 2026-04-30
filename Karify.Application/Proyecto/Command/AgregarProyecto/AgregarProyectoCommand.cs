using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Command.AgregarProyecto
{
    public class AgregarProyectoCommand : IRequest<AgregarProyectoCommandDTO>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdAlumno { get; set; }
        public int IdProfesor { get; set; }
    }
}
