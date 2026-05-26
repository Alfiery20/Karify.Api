using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Profesor.Command.EditarProfesor
{
    public class EditarProfesorCommand : IRequest<EditarProfesorCommandDTO>
    {
        public int IdProfesor { get; set; }
        public string Emeal { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int IdRol{ get; set; }
    }
}
