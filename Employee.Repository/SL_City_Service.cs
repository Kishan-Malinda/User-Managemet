using Dapper;
using Employee.Models;
using Employee.Models.Models;
using Employee.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository
{
    public class SL_City_Service : ISL_City_Repository
    {
        private readonly string _connectionString;
        public SL_City_Service(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<BaseResponse> GetAllCities()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var results = await connection.QueryAsync<SL_City>("[getAllCities]", commandType: CommandType.StoredProcedure);
                    return new BaseResponseRepository().GetSuccessResponse(results);
                }
            }
            catch (SqlException ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }
        }
    }
}
