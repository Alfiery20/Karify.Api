using Dapper;
using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using Karify.Application.DatosMaestros.Query.ObtenerEscuela;
using Karify.Application.DatosMaestros.Query.ObtenerFacultad;
using Karify.Application.Usuario.Command.ActualizarInformacion;
using Karify.Application.Usuario.Query.ObtenerInformacionUsuario;
using Karify.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Karify.Persistence.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDataBase _dataBase;

        public UsuarioRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<ObtenerInformacionUsuarioQueryDTO> ObtenerInformacionPersonal(ObtenerInformacionUsuarioQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                ObtenerInformacionUsuarioQueryDTO informacionPersonal = new();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdUsuario", query.IdUsuario, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerInformacionPersonal]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        informacionPersonal = new ObtenerInformacionUsuarioQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            CodigoUniversitario = Convert.IsDBNull(reader["CODIGO_UNIVERSITARIO"]) ? "" : reader["CODIGO_UNIVERSITARIO"].ToString(),
                            TipoDocumento = Convert.IsDBNull(reader["TIPO_DOCUMENTO"]) ? "" : reader["TIPO_DOCUMENTO"].ToString(),
                            NumeroDocumento = Convert.IsDBNull(reader["NUMERO_DOCUMENTO"]) ? "" : reader["NUMERO_DOCUMENTO"].ToString(),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            ApellidoPaterno = Convert.IsDBNull(reader["APELLIDO_PATERNO"]) ? "" : reader["APELLIDO_PATERNO"].ToString(),
                            ApellidoMaterno = Convert.IsDBNull(reader["APELLIDO_MATERNO"]) ? "" : reader["APELLIDO_MATERNO"].ToString(),
                            Correo = Convert.IsDBNull(reader["CORREO"]) ? "" : reader["CORREO"].ToString(),
                            Telefono = Convert.IsDBNull(reader["TELEFONO"]) ? "" : reader["TELEFONO"].ToString(),
                            IdFacultad = Convert.IsDBNull(reader["ID_FACULTAD"]) ? 0 : Convert.ToInt32(reader["ID_FACULTAD"].ToString()),
                            IdEscuela = Convert.IsDBNull(reader["ID_ESCUELA"]) ? 0 : Convert.ToInt32(reader["ID_ESCUELA"].ToString())
                        };
                    }
                }
                return informacionPersonal;
            }
        }

        public async Task<ActualizarInformacionCommandDTO> ActualizarInformacionPersonal(ActualizarInformacionCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdUsuario", command.IdUsuario, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pCodigoUniversitario", command.CodigoUniversitario, DbType.String, ParameterDirection.Input);
                parameters.Add("@pTipoDocumento", command.TipoDocumento, DbType.String, ParameterDirection.Input);
                parameters.Add("@pNumeroDocumento", command.NumeroDocumento, DbType.String, ParameterDirection.Input);
                parameters.Add("@pNombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pApellidoPaterno", command.ApellidoPaterno, DbType.String, ParameterDirection.Input);
                parameters.Add("@pApellidoMaterno", command.ApellidoMaterno, DbType.String, ParameterDirection.Input);
                parameters.Add("@pTelefono", command.Telefono, DbType.String, ParameterDirection.Input);
                parameters.Add("@pEscuela", command.IdEscuela, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ActualizarDatosUsuario]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                var mensaje = parameters.Get<string>("msj");
                return new ActualizarInformacionCommandDTO()
                {
                    Mensaje = mensaje
                };
            }
        }
    }
}
