using Karify.Application.Rol.Command.AgregarRol;
using Karify.Application.Rol.Command.EditarRol;
using Karify.Application.Rol.Command.EliminarRol;
using Karify.Application.Rol.Query.ObtenerRol;
using Karify.Application.Rol.Query.VerRol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Common.Interface.Repositories
{
    public interface IRolRepository
    {
        Task<AgregarRolCommandDTO> AgregarRol(AgregarRolCommand command);
        Task<EditarRolCommandDTO> EditarRol(EditarRolCommand command);
        Task<EliminarRolCommandDTO> EliminarRol(EliminarRolCommand command);
        Task<IEnumerable<ObtenerRolQueryDTO>> ObtenerRol(ObtenerRolQuery query);
        Task<VerRolQueryDTO> VerRol(VerRolQuery query);
        Task<IEnumerable<Permiso>> ObtenerPermiso(int idRol);
    }
}
