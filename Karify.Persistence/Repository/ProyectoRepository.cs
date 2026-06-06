using Dapper;
using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using Karify.Application.Proyecto.Command.AgregarProyecto;
using Karify.Application.Proyecto.Command.EditarProyecto;
using Karify.Application.Proyecto.Query.ObtenerProyecto;
using Karify.Application.Proyecto.Query.VerProyecto;
using Karify.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

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
                parameters.Add("@pNombreArchivo", command.NombreArchivo, DbType.String, ParameterDirection.Input);
                parameters.Add("@pArchivoBase64", Convert.FromBase64String(command.ArchivoEncriptado), DbType.Binary, ParameterDirection.Input);
                parameters.Add("@pPeso", command.Peso, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pIdAlumno", command.IdAlumno, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pIdProfesor", command.IdProfesor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@idNuevoProyecto", 0, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_AgregarProyecto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                response.Mensaje = parameters.Get<string>("msj");
                response.IdProyecto = parameters.Get<int>("idNuevoProyecto");

                return response;
            }
        }

        public async Task<EditarProyectoCommandDTO> EditarProyecto(EditarProyectoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                EditarProyectoCommandDTO response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdProyecto", command.IdProyecto, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pNombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pDescripcion", command.Descripcion, DbType.String, ParameterDirection.Input);
                parameters.Add("@pIdProfesor", command.IdProfesor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EditarProyecto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                response.Mensaje = parameters.Get<string>("msj");

                return response;
            }
        }

        public async Task<IEnumerable<ObtenerProyectoQueryDTO>> ObtenerProyecto(ObtenerProyectoQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<ObtenerProyectoQueryDTO> proyectos = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pNombre", query.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pIdAlumno", query.IdAlumno, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerProyecto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        proyectos.Add(new ObtenerProyectoQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Descripcion = Convert.IsDBNull(reader["DESCRIPCION"]) ? "" : reader["DESCRIPCION"].ToString(),
                            Profesor = Convert.IsDBNull(reader["PROFESOR"]) ? "" : reader["PROFESOR"].ToString(),
                            FechaRegistro = Convert.IsDBNull(reader["FECHA_REGISTRO"]) ? DateTime.MinValue : Convert.ToDateTime(reader["FECHA_REGISTRO"]),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString()
                        });
                    }
                }
                return proyectos;
            }
        }

        public async Task<VerProyectoQueryDTO> VerProyecto(VerProyectoQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                VerProyectoQueryDTO response = new VerProyectoQueryDTO();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdProyecto", query.IdProyecto, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerProyecto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response.IdProyecto = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString());
                        response.Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString();
                        response.Descripcion = Convert.IsDBNull(reader["DESCRIPCION"]) ? "" : reader["DESCRIPCION"].ToString();
                        response.Profesor = Convert.IsDBNull(reader["PROFESOR"]) ? 0 : Convert.ToInt32(reader["PROFESOR"].ToString());
                        response.FechaRegistro = Convert.IsDBNull(reader["FECHA_REGISTRO"]) ? DateTime.MinValue : Convert.ToDateTime(reader["FECHA_REGISTRO"]);
                    }
                }
                return response;
            }
        }
    }
}
