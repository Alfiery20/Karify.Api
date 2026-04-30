using Dapper;
using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using Karify.Application.Common.Utils;
using Karify.Application.Proyecto.Command.AgregarProyecto;
using Karify.Application.Rol.Command.AgregarRol;
using Karify.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karify.Persistence.Repository
{
    public class ProyectoRepository : IProyectoRepository
    {
        private readonly IDataBase _dataBase;
        private readonly IDateTimeService _dateTimeService;

        public ProyectoRepository(
            IServiceProvider serviceProvider,
            IDateTimeService dateTimeService
            )
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
            this._dateTimeService = dateTimeService;
        }

        public async Task<AgregarProyectoCommandDTO> AgregarProyecto(AgregarProyectoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                AgregarProyectoCommandDTO response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pNombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pDescripcion", command.Descripcion, DbType.String, ParameterDirection.Input);
                parameters.Add("@pFechaRegistro", this._dateTimeService.HoraLocal(), DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@pIdAlumno", command.IdAlumno, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pIdProfesor", command.IdProfesor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_AgregarProyecto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                response.Mensaje = parameters.Get<string>("msj");

                return response;
            }
        }
    }
}
