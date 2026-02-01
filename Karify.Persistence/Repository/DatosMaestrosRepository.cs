using Dapper;
using Karify.Application.Common.Interface;
using Karify.Application.Common.Interface.Repositories;
using Karify.Application.DatosMaestros.Query.ObtenerEscuela;
using Karify.Application.DatosMaestros.Query.ObtenerFacultad;
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
                    "[dbo].[usp_ObtenerFacultad]",
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
                    "[dbo].[usp_ObtenerEscuela]",
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
    }
}
