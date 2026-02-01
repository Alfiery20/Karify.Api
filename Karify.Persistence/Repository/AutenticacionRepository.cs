using Dapper;
using Karify.Application.Autenticacion.Command.Login;
using Karify.Application.Autenticacion.Command.LoginGoogle;
using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
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
    public class AutenticacionRepository : IAutenticacionRepository
    {
        private readonly IDataBase _dataBase;

        public AutenticacionRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<LoginCommandDTO> IniciarSesion(LoginGoogleCommand query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                var response = new LoginCommandDTO();

                parameters.Add("@pemail", query.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("@pnombre", query.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@papellidos", query.Apellido, DbType.String, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[sp_IniciarSesion]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response = new LoginCommandDTO
                        {
                            IdUsuario = Convert.IsDBNull(reader["ID_USUARIO"]) ? 0 : Convert.ToInt32(reader["ID_USUARIO"].ToString()),
                            CodigoUniversitario = Convert.IsDBNull(reader["CODIGO_UNIVERSITARIO"]) ? string.Empty : reader["CODIGO_UNIVERSITARIO"].ToString(),
                            TipoDocumento = Convert.IsDBNull(reader["TIPO_DOCUMENTO"]) ? string.Empty : reader["TIPO_DOCUMENTO"].ToString(),
                            NumeroDocumento = Convert.IsDBNull(reader["NUMERO_DOCUMENTO"]) ? string.Empty : reader["NUMERO_DOCUMENTO"].ToString(),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? string.Empty : reader["NOMBRE"].ToString(),
                            ApellidoPaterno = Convert.IsDBNull(reader["APELLIDO_PATERNO"]) ? string.Empty : reader["APELLIDO_PATERNO"].ToString(),
                            ApellidoMaterno = Convert.IsDBNull(reader["APELLIDO_MATERNO"]) ? string.Empty : reader["APELLIDO_MATERNO"].ToString(),
                            Correo = Convert.IsDBNull(reader["CORREO"]) ? string.Empty : reader["CORREO"].ToString(),
                            Telefono = Convert.IsDBNull(reader["TELEFONO"]) ? string.Empty : reader["TELEFONO"].ToString(),
                            IdEscuela = Convert.IsDBNull(reader["ID_ESCUELA"]) ? 0 : Convert.ToInt32(reader["ID_ESCUELA"].ToString()),
                            NombreEscuela = Convert.IsDBNull(reader["NOMBRE_ESCUELA"]) ? string.Empty : reader["NOMBRE_ESCUELA"].ToString(),
                            IdFacultad = Convert.IsDBNull(reader["ID_FACULTAD"]) ? 0 : Convert.ToInt32(reader["ID_FACULTAD"].ToString()),
                            NombreFacultad = Convert.IsDBNull(reader["NOMBRE_FACULTAD"]) ? string.Empty : reader["NOMBRE_FACULTAD"].ToString(),
                            LLenarPerfil = Convert.IsDBNull(reader["ES_NECESARIO_LLENAR"]) ? false : Convert.ToBoolean(reader["ES_NECESARIO_LLENAR"].ToString()),
                            IdRol = Convert.IsDBNull(reader["ID_ROL"]) ? 0 : Convert.ToInt32(reader["ID_ROL"].ToString()),
                            Rol = Convert.IsDBNull(reader["ROL"]) ? string.Empty : reader["ROL"].ToString(),
                        };
                    }
                }
                return response;
            }
        }

        public async Task<IEnumerable<Menu>> ObtenerMenu(int IdRol)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                List<Menu> response = new();

                parameters.Add("@pIdRol", IdRol, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerMenu]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        response.Add(new Menu
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? string.Empty : reader["NOMBRE"].ToString(),
                            Ruta = Convert.IsDBNull(reader["RUTA"]) ? string.Empty : reader["RUTA"].ToString(),
                        });
                    }
                }
                return response;
            }
        }
    }
}
