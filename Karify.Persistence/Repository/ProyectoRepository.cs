using Dapper;
using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using Karify.Application.Proyecto.Command.AgregarProyecto;
using Karify.Application.Proyecto.Command.AprobarProyecto;
using Karify.Application.Proyecto.Command.CancelarProyecto;
using Karify.Application.Proyecto.Command.EditarProyecto;
using Karify.Application.Proyecto.Command.RechazarProyecto;
using Karify.Application.Proyecto.Query.ObtenerProyecto;
using Karify.Application.Proyecto.Query.ObtenerProyectoPorProfesor;
using Karify.Application.Proyecto.Query.VerProyecto;
using Karify.Application.Proyecto.Query.VerProyectoRevision;
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
                parameters.Add("@pArchivoBase64", command.ArchivoEncriptado, DbType.String, ParameterDirection.Input);
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
                        response.Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString();
                        response.NombreProfesor = Convert.IsDBNull(reader["NOMBRE_PROFESOR"]) ? "" : reader["NOMBRE_PROFESOR"].ToString();
                        response.NombreArchivo = Convert.IsDBNull(reader["NOMBRE_ARCHIVO"]) ? "" : reader["NOMBRE_ARCHIVO"].ToString();
                        response.FechaRegistro = Convert.IsDBNull(reader["FECHA_REGISTRO"]) ? DateTime.MinValue : Convert.ToDateTime(reader["FECHA_REGISTRO"]);
                    }
                }
                return response;
            }
        }

        public async Task<IEnumerable<ObtenerProyectoPorProfesorQueryDTO>> ObtenerProyectoPorProfesor(ObtenerProyectoPorProfesorQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<ObtenerProyectoPorProfesorQueryDTO> proyectos = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdUsuario", query.IdProfesor, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerProyectoPorProfesor]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        proyectos.Add(new ObtenerProyectoPorProfesorQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Descripcion = Convert.IsDBNull(reader["DESCRIPCION"]) ? "" : reader["DESCRIPCION"].ToString(),
                            Alumno = Convert.IsDBNull(reader["ALUMNO"]) ? "" : reader["ALUMNO"].ToString(),
                            FechaRegistro = Convert.IsDBNull(reader["FECHA_REGISTRO"]) ? DateTime.MinValue : Convert.ToDateTime(reader["FECHA_REGISTRO"]),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? "" : reader["ESTADO"].ToString()
                        });
                    }
                }
                return proyectos;
            }
        }

        public async Task<VerProyectoRevisionQueryDTO> VerProyectoRevision(VerProyectoRevisionQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                VerProyectoRevisionQueryDTO response = new VerProyectoRevisionQueryDTO();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdProyecto", query.IdProyecto, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerProyectoRevision]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response.IdProyecto = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString());
                        response.Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString();
                        response.Descripcion = Convert.IsDBNull(reader["DESCRIPCION"]) ? "" : reader["DESCRIPCION"].ToString();
                        response.FechaRegistro = Convert.IsDBNull(reader["FECHA_REGISTRO"]) ? DateTime.MinValue : Convert.ToDateTime(reader["FECHA_REGISTRO"]);
                        response.Archivo = Convert.IsDBNull(reader["ARCHIVO"]) ? "" : reader["ARCHIVO"].ToString();
                        response.NombreArchivo = Convert.IsDBNull(reader["NOMBRE_ARCHIVO"]) ? "" : reader["NOMBRE_ARCHIVO"].ToString();
                        response.NumeroDocumento = Convert.IsDBNull(reader["NUMERO_DOCUMENTO"]) ? "" : reader["NUMERO_DOCUMENTO"].ToString();
                        response.CodigoUniversitario = Convert.IsDBNull(reader["CODIGO_UNIVERSITARIO"]) ? "" : reader["CODIGO_UNIVERSITARIO"].ToString();
                        response.NombreAlumno = Convert.IsDBNull(reader["NOMBRE_ALUMNO"]) ? "" : reader["NOMBRE_ALUMNO"].ToString();
                        response.ApellidoPateno = Convert.IsDBNull(reader["APELLIDO_PATERNO_ALUMNO"]) ? "" : reader["APELLIDO_PATERNO_ALUMNO"].ToString();
                        response.ApellidoMaterno = Convert.IsDBNull(reader["APELLIDO_MATERNO_ALUMNO"]) ? "" : reader["APELLIDO_MATERNO_ALUMNO"].ToString();
                    }
                }
                return response;
            }
        }

        public async Task<AprobarProyectoCommandDTO> AprobarProyecto(AprobarProyectoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                AprobarProyectoCommandDTO response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdProyecto", command.IdProyecto, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pIdUsuario", command.IdUsuario, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pFechaRespuesta", this._dateTimeService.HoraLocal(), DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_AprobarProyecto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                response.Mensaje = parameters.Get<string>("msj");

                return response;
            }
        }

        public async Task<RechazarProyectoCommandDTO> RechazarProyecto(RechazarProyectoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                RechazarProyectoCommandDTO response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdProyecto", command.IdProyecto, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pIdUsuario", command.IdUsuario, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pFechaRespuesta", this._dateTimeService.HoraLocal(), DbType.DateTime, ParameterDirection.Input);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_RechazarProyecto]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                response.Mensaje = parameters.Get<string>("msj");

                return response;
            }
        }

        public async Task<AprobacionProyectoCorreo> ObtenerInformacionAprobacion(int idProyecto)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                AprobacionProyectoCorreo response = new AprobacionProyectoCorreo();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdProyecto", idProyecto, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerInformacionAprobacion]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response.NumeroDocumento = Convert.IsDBNull(reader["NUMERO_DOCUMENTO"]) ? "" : reader["NUMERO_DOCUMENTO"].ToString();
                        response.CodigoUniversitario = Convert.IsDBNull(reader["CODIGO_UNIVERSITARIO"]) ? "" : reader["CODIGO_UNIVERSITARIO"].ToString();
                        response.Correo = Convert.IsDBNull(reader["CORREO_ALUMNO"]) ? "" : reader["CORREO_ALUMNO"].ToString();
                        response.Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString();
                        response.ApellidoPaterno = Convert.IsDBNull(reader["APELLIDO_PATERNO"]) ? "" : reader["APELLIDO_PATERNO"].ToString();
                        response.ApellidoMaterno = Convert.IsDBNull(reader["APELLIDO_MATERNO"]) ? "" : reader["APELLIDO_MATERNO"].ToString();
                        response.NombreProfesor = Convert.IsDBNull(reader["NOMBRE_PROFESOR"]) ? "" : reader["NOMBRE_PROFESOR"].ToString();
                        response.ApellidoPaternoProfesor = Convert.IsDBNull(reader["APELLIDO_PATERNO_PROFESOR"]) ? "" : reader["APELLIDO_PATERNO_PROFESOR"].ToString();
                        response.ApellidoMaternoProfesor = Convert.IsDBNull(reader["APELLIDO_MATERNO_PROFESOR"]) ? "" : reader["APELLIDO_MATERNO_PROFESOR"].ToString();
                        response.NombreProyecto = Convert.IsDBNull(reader["NOMBRE_PROYECTO"]) ? "" : reader["NOMBRE_PROYECTO"].ToString();
                        response.DescripcionProyecto = Convert.IsDBNull(reader["DESCRIPCION_PROYECTO"]) ? "" : reader["DESCRIPCION_PROYECTO"].ToString();
                        response.FechaResultado = Convert.IsDBNull(reader["FECHA_RESULTADO"]) ? DateTime.MinValue : Convert.ToDateTime(reader["FECHA_RESULTADO"]);
                    }
                }
                return response;
            }
        }

        public async Task<RechazoProyectoCorreo> ObtenerInformacionRechazo(int idProyecto)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                RechazoProyectoCorreo response = new RechazoProyectoCorreo();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdProyecto", idProyecto, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerInformacionAprobacion]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response.NumeroDocumento = Convert.IsDBNull(reader["NUMERO_DOCUMENTO"]) ? "" : reader["NUMERO_DOCUMENTO"].ToString();
                        response.CodigoUniversitario = Convert.IsDBNull(reader["CODIGO_UNIVERSITARIO"]) ? "" : reader["CODIGO_UNIVERSITARIO"].ToString();
                        response.Correo = Convert.IsDBNull(reader["CORREO_ALUMNO"]) ? "" : reader["CORREO_ALUMNO"].ToString();
                        response.Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString();
                        response.ApellidoPaterno = Convert.IsDBNull(reader["APELLIDO_PATERNO"]) ? "" : reader["APELLIDO_PATERNO"].ToString();
                        response.ApellidoMaterno = Convert.IsDBNull(reader["APELLIDO_MATERNO"]) ? "" : reader["APELLIDO_MATERNO"].ToString();
                        response.NombreProfesor = Convert.IsDBNull(reader["NOMBRE_PROFESOR"]) ? "" : reader["NOMBRE_PROFESOR"].ToString();
                        response.ApellidoPaternoProfesor = Convert.IsDBNull(reader["APELLIDO_PATERNO_PROFESOR"]) ? "" : reader["APELLIDO_PATERNO_PROFESOR"].ToString();
                        response.ApellidoMaternoProfesor = Convert.IsDBNull(reader["APELLIDO_MATERNO_PROFESOR"]) ? "" : reader["APELLIDO_MATERNO_PROFESOR"].ToString();
                        response.NombreProyecto = Convert.IsDBNull(reader["NOMBRE_PROYECTO"]) ? "" : reader["NOMBRE_PROYECTO"].ToString();
                        response.DescripcionProyecto = Convert.IsDBNull(reader["DESCRIPCION_PROYECTO"]) ? "" : reader["DESCRIPCION_PROYECTO"].ToString();
                        response.FechaResultado = Convert.IsDBNull(reader["FECHA_RESULTADO"]) ? DateTime.MinValue : Convert.ToDateTime(reader["FECHA_RESULTADO"]);
                    }
                }
                return response;
            }
        }

        public async Task<CancelarProyectoCommandDTO> CancelarProyecto(CancelarProyectoCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                CancelarProyectoCommandDTO response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidProyecto", command.IdProyecto, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pidUsuario", command.IdUsuario, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pfechaCancelacion", this._dateTimeService.HoraLocal(), DbType.DateTime, ParameterDirection.Input);

                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_CancelarAnalisis]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                response.Mensaje = parameters.Get<string>("msj");

                return response;
            }
        }
    }
}
