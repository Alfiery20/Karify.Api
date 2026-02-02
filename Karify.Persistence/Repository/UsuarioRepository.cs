using Dapper;
using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using Karify.Application.DatosMaestros.Query.ObtenerEscuela;
using Karify.Application.DatosMaestros.Query.ObtenerFacultad;
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
    }
}
