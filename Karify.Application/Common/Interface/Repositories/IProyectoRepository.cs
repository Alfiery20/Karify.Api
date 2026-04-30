using Karify.Application.Proyecto.Command.AgregarProyecto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Common.Interface.Repositories
{
    public interface IProyectoRepository
    {
        Task<AgregarProyectoCommandDTO> AgregarProyecto(AgregarProyectoCommand command);
    }
}
