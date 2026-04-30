using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Proyecto.Command.EditarProyecto
{
    public class EditarProyectoCommand : IRequest<EditarProyectoCommandDTO>
    {
        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdProfesor { get; set; }
    }
}
