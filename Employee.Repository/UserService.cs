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
    public class UserService : IUserRepository
    {
        private readonly string _connectionString;
        public UserService(string connectionString)
        {
            _connectionString = connectionString;        
        }

        // Delete Users
        public async Task<BaseResponse> DeleteUser(string userID)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@userID",userID);
                    var results = await connection.QueryAsync<User>("[deleteUser]",para, commandType: CommandType.StoredProcedure);
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

        //Get All Users
        public async Task<BaseResponse> GetAllUsers()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var results = await connection.QueryAsync<User>("[getUserDetails]", commandType: CommandType.StoredProcedure);
                    return new BaseResponseRepository().GetSuccessResponse(results);
                }
            }
            catch (SqlException ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }catch(Exception ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }
        }
        // Get Single Users
        public async Task<BaseResponse> GetSingleUser(string userID)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@userID", userID);
                    var results = await connection.QueryAsync<User>("[getUserDetails]", para,commandType: CommandType.StoredProcedure);
                    return new BaseResponseRepository().GetSuccessResponse(results);
                }
            }
            catch (SqlException ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }catch (Exception ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }
        }

        public async Task<BaseResponse> InsertUser(User user)
        {
            try
            {
                using ( var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.password);
                    para.Add("@userName",user.userName);
                    para.Add("@DOB",user.DOB);
                    para.Add("@city",user.city);
                    para.Add("@gender",user.gender);
                    para.Add("@password",hashedPassword);
                    para.Add("@active",user.active);
                    var results = await connection.QueryAsync<User>("[addUser]", para, commandType: CommandType.StoredProcedure);
                    Console.WriteLine(results);
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

        public async Task<BaseResponse> UpdateUser(User user)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@userID", user.userID);
                    para.Add("@userName", user.userName);
                    para.Add("@DOB", user.DOB);
                    para.Add("@city", user.city);
                    para.Add("@gender", user.gender);
                    para.Add("@active", user.active);
                    var results = await connection.QueryAsync<User>("[UpdateUser]", para, commandType: CommandType.StoredProcedure);
                    return new BaseResponseRepository().GetSuccessResponse(results);
                }
            }catch(SqlException ex){
                return new BaseResponseRepository().GetErrorResponse(ex);
            }
            catch (Exception ex)
            {
                return new BaseResponseRepository().GetErrorResponse(ex);
            }
        }
    }
}
