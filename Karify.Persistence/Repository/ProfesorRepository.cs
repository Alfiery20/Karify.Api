using Dapper;
using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using Karify.Application.Profesor.Command.AgregarProfesor;
using Karify.Application.Profesor.Command.EditarProfesor;
using Karify.Application.Profesor.Command.EliminarProfesor;
using Karify.Application.Profesor.Query.ObtenerProfesor;
using Karify.Application.Profesor.Query.VerProfesor;
using Karify.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Karify.Persistence.Repository
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly IDataBase _dataBase;

        public ProfesorRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<AgregarProfesorCommandDTO> AgregarProfesor(AgregarProfesorCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                AgregarProfesorCommandDTO response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pemail", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pNombre", command.Emeal, DbType.String, ParameterDirection.Input);
                parameters.Add("@pApellidoPaterno", command.ApellidoPaterno, DbType.String, ParameterDirection.Input);
                parameters.Add("@pApellidoMaterno", command.ApellidoMaterno, DbType.String, ParameterDirection.Input);
                parameters.Add("@pidRol", command.IdRol, DbType.Int32, ParameterDirection.Input);

                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_AgregarProfesor]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                response.Mensaje = parameters.Get<string>("msj");

                return response;
            }
        }

        public async Task<EditarProfesorCommandDTO> EditarProfesor(EditarProfesorCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                EditarProfesorCommandDTO response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidProfesor", command.IdProfesor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pemail", command.Emeal, DbType.String, ParameterDirection.Input);
                parameters.Add("@pNombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pApellidoPaterno", command.ApellidoPaterno, DbType.String, ParameterDirection.Input);
                parameters.Add("@pApellidoMaterno", command.ApellidoMaterno, DbType.String, ParameterDirection.Input);
                parameters.Add("@pidRol", command.IdRol, DbType.Int32, ParameterDirection.Input);

                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EditarProfesor]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                response.Mensaje = parameters.Get<string>("msj");

                return response;
            }
        }

        public async Task<EliminarProfesorCommandDTO> EliminarProfesor(EliminarProfesorCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                EliminarProfesorCommandDTO response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pId", command.IdProfesor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EliminarProfesor]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                response.Mensaje = parameters.Get<string>("msj");

                return response;
            }
        }

        public async Task<IEnumerable<ObtenerProfesorQueryDTO>> ObtenerProfesor(ObtenerProfesorQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<ObtenerProfesorQueryDTO> escuelas = new();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pNombre", query.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pIdFacultad", query.IdFacultad, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pIdEscuela", query.IdEscuela, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerProfesor]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        escuelas.Add(new ObtenerProfesorQueryDTO()
                        {
                            IdProfesor = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            ApellidoPaterno = Convert.IsDBNull(reader["APELLIDO_PATERNO"]) ? "" : reader["APELLIDO_PATERNO"].ToString(),
                            ApellidoMaterno = Convert.IsDBNull(reader["APELLIDO_MATERNO"]) ? "" : reader["APELLIDO_MATERNO"].ToString(),
                            TipoDocumento = Convert.IsDBNull(reader["TIPO_DOCUMENTO"]) ? "" : reader["TIPO_DOCUMENTO"].ToString(),
                            NumeroDocumento = Convert.IsDBNull(reader["NUMERO_DOCUMENTO"]) ? "" : reader["NUMERO_DOCUMENTO"].ToString(),
                            Telefono = Convert.IsDBNull(reader["TELEFONO"]) ? "" : reader["TELEFONO"].ToString(),
                            CodigoUniversitario = Convert.IsDBNull(reader["CODIGO_UNIVERSITARIO"]) ? "" : reader["CODIGO_UNIVERSITARIO"].ToString(),
                            Correo = Convert.IsDBNull(reader["CORREO"]) ? "" : reader["CORREO"].ToString(),
                            Facultad = Convert.IsDBNull(reader["FACULTAD"]) ? "" : reader["FACULTAD"].ToString(),
                            Escuela = Convert.IsDBNull(reader["ESCUELA"]) ? "" : reader["ESCUELA"].ToString(),
                            Rol = Convert.IsDBNull(reader["ROL"]) ? "" : reader["ROL"].ToString(),
                            CompletarPerfil = Convert.IsDBNull(reader["COMPLETAR_PERFIL"]) ? false : Convert.ToBoolean(reader["COMPLETAR_PERFIL"]),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? false : Convert.ToBoolean(reader["ESTADO"])
                        });
                    }
                }
                return escuelas;
            }
        }

        public async Task<VerProfesorQueryDTO> VerProfesor(VerProfesorQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                VerProfesorQueryDTO response = new VerProfesorQueryDTO();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pid", query.IdProfesor, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerProfesor]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response.IdProfesor = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString());
                        response.Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString();
                        response.ApellidoPaterno = Convert.IsDBNull(reader["APELLIDO_PATERNO"]) ? "" : reader["APELLIDO_PATERNO"].ToString();
                        response.ApellidoMaterno = Convert.IsDBNull(reader["APELLIDO_MATERNO"]) ? "" : reader["APELLIDO_MATERNO"].ToString();
                        response.TipoDocumento = Convert.IsDBNull(reader["TIPO_DOCUMENTO"]) ? "" : reader["TIPO_DOCUMENTO"].ToString();
                        response.NumeroDocumento = Convert.IsDBNull(reader["NUMERO_DOCUMENTO"]) ? "" : reader["NUMERO_DOCUMENTO"].ToString();
                        response.Telefono = Convert.IsDBNull(reader["TELEFONO"]) ? "" : reader["TELEFONO"].ToString();
                        response.CodigoUniversitario = Convert.IsDBNull(reader["CODIGO_UNIVERSITARIO"]) ? "" : reader["CODIGO_UNIVERSITARIO"].ToString();
                        response.Correo = Convert.IsDBNull(reader["CORREO"]) ? "" : reader["CORREO"].ToString();
                        response.Facultad = Convert.IsDBNull(reader["FACULTAD"]) ? 0 : Convert.ToInt32(reader["FACULTAD"].ToString());
                        response.Escuela = Convert.IsDBNull(reader["ESCUELA"]) ? 0 : Convert.ToInt32(reader["ESCUELA"].ToString());
                        response.Rol = Convert.IsDBNull(reader["ROL"]) ? 0 : Convert.ToInt32(reader["ROL"].ToString());
                    }
                }
                return response;
            }
        }

        public async Task<string> ObtenerCorreoProfesor(int idProfesor)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                string response = "";
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pidProfesor", idProfesor, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_ObtenerCorreoProfesor]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response = Convert.IsDBNull(reader["CORREO"]) ? "" : reader["CORREO"].ToString();
                    }
                }
                return response;
            }
        }
    }
}
