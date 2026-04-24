using Azure;
using Dapper;
using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using Karify.Application.Common.Utils;
using Karify.Application.DatosMaestros.Query.ObtenerEscuela;
using Karify.Application.Rol.Command.AgregarRol;
using Karify.Application.Rol.Command.EditarRol;
using Karify.Application.Rol.Command.EliminarRol;
using Karify.Application.Rol.Query.ObtenerRol;
using Karify.Application.Rol.Query.VerRol;
using Karify.Application.Usuario.Query.ObtenerInformacionUsuario;
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
    public class RolRepository : IRolRepository
    {
        private readonly IDataBase _dataBase;

        public RolRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<AgregarRolCommandDTO> AgregarRol(AgregarRolCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                AgregarRolCommandDTO response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pNombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pPermiso", ConvertXMLMapper.ConvertirPermisosAXml(command.Permisos), DbType.Xml, ParameterDirection.Input);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_AgregarRoles]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                response.Mensaje = parameters.Get<string>("msj");

                return response;
            }
        }

        public async Task<EditarRolCommandDTO> EditarRol(EditarRolCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                EditarRolCommandDTO response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pid", command.IdRol, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@pNombre", command.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("@pPermiso", ConvertXMLMapper.ConvertirPermisosAXml(command.Permisos), DbType.String, ParameterDirection.Input);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EditarRoles]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                response.Mensaje = parameters.Get<string>("msj");

                return response;
            }
        }

        public async Task<EliminarRolCommandDTO> EliminarRol(EliminarRolCommand command)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                EliminarRolCommandDTO response = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pid", command.IdRol, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@msj", "", DbType.String, ParameterDirection.Output);

                using var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_EliminarRol]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);

                response.Mensaje = parameters.Get<string>("msj");

                return response;
            }
        }

        public async Task<IEnumerable<ObtenerRolQueryDTO>> ObtenerRol(ObtenerRolQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<ObtenerRolQueryDTO> escuelas = new();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pNombre", query.Nombre, DbType.String, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerRoles]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        escuelas.Add(new ObtenerRolQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString(),
                            Estado = Convert.IsDBNull(reader["ESTADO"]) ? false : Convert.ToBoolean(reader["ESTADO"])
                        });
                    }
                }
                return escuelas;
            }
        }

        public async Task<VerRolQueryDTO> VerRol(VerRolQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                VerRolQueryDTO response = new VerRolQueryDTO();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pid", query.IdRol, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_VerRoles]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        var prueba = reader["ESTADO"].ToString();
                        response.IdRol = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString());
                        response.Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString();
                        response.Estado = Convert.IsDBNull(reader["ESTADO"]) ? false : Convert.ToBoolean(reader["ESTADO"]);
                    }
                }
                return response;
            }
        }

        public async Task<IEnumerable<Permiso>> ObtenerPermiso(int idRol)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<Permiso> permisos = new();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pId", idRol, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_ObtenerPermisos]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        permisos.Add(new Permiso()
                        {
                            IdRuta = Convert.IsDBNull(reader["ID_RUTA"]) ? 0 : Convert.ToInt32(reader["ID_RUTA"].ToString()),
                            Ruta = Convert.IsDBNull(reader["RUTA"]) ? "" : reader["RUTA"].ToString(),
                            IsPermiso = Convert.IsDBNull(reader["IS_PERMISO"]) ? false : reader["IS_PERMISO"].ToString() == "1"
                        });
                    }
                }
                return permisos;
            }
        }
    }
}
