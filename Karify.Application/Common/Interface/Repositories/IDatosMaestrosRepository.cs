using Karify.Application.DatosMaestros.Query.ObtenerEscuela;
using Karify.Application.DatosMaestros.Query.ObtenerFacultad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Application.Common.Interface.Repositories
{
    public interface IDatosMaestrosRepository
    {
        Task<IEnumerable<ObtenerFacultadQueryDTO>> ObtenerFacultad();
        Task<IEnumerable<ObtenerEscuelaQueryDTO>> ObtenerEscuela(ObtenerEscuelaQuery query);
    }
}
