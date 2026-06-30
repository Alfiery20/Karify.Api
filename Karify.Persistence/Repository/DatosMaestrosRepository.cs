using Dapper;
using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using Karify.Application.DatosMaestros.Query.ObtenerAlumno;
using Karify.Application.DatosMaestros.Query.ObtenerEscuela;
using Karify.Application.DatosMaestros.Query.ObtenerFacultad;
using Karify.Application.DatosMaestros.Query.ObtenerProfesor;
using Karify.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Karify.Persistence.Repository
{
    public class DatosMaestrosRepository : IDatosMaestrosRepository
    {
        private readonly IDataBase _dataBase;

        public DatosMaestrosRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SqlDataBase));
        }

        public async Task<IEnumerable<ObtenerFacultadQueryDTO>> ObtenerFacultad()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<ObtenerFacultadQueryDTO> facultades = new();

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_DM_ObtenerFacultad]",
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        facultades.Add(new ObtenerFacultadQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString()
                        });
                    }
                }
                return facultades;
            }
        }

        public async Task<IEnumerable<ObtenerEscuelaQueryDTO>> ObtenerEscuela(ObtenerEscuelaQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<ObtenerEscuelaQueryDTO> escuelas = new();

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pIdFacultad", query.IdFacultad, DbType.Int32, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_DM_ObtenerEscuela]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        escuelas.Add(new ObtenerEscuelaQueryDTO()
                        {
                            Id = Convert.IsDBNull(reader["ID"]) ? 0 : Convert.ToInt32(reader["ID"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString()
                        });
                    }
                }
                return escuelas;
            }
        }

        public async Task<IEnumerable<ObtenerProfesorQueryDMDTO>> ObtenerProfesorPorEscuela(ObtenerProfesorDMQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<ObtenerProfesorQueryDMDTO> profesores = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pNombre", query.Nombre, DbType.String, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_DM_ObtenerProfesor]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        profesores.Add(new ObtenerProfesorQueryDMDTO()
                        {
                            Codigo = Convert.IsDBNull(reader["CODIGO"]) ? 0 : Convert.ToInt32(reader["CODIGO"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString()
                        });
                    }
                }
                return profesores;
            }
        }

        public async Task<IEnumerable<ObtenerAlumnoDMQueryDTO>> ObtenerAlumnoCotesista(ObtenerAlumnoDMQuery query)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                List<ObtenerAlumnoDMQueryDTO> profesores = new();
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@pNombre", query.Nombre, DbType.String, ParameterDirection.Input);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_DM_ObtenerCotesista]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        profesores.Add(new ObtenerAlumnoDMQueryDTO()
                        {
                            Codigo = Convert.IsDBNull(reader["CODIGO"]) ? 0 : Convert.ToInt32(reader["CODIGO"].ToString()),
                            Nombre = Convert.IsDBNull(reader["NOMBRE"]) ? "" : reader["NOMBRE"].ToString()
                        });
                    }
                }
                return profesores;
            }
        }
    }
}
