using Employee.Models;
using Employee.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<BaseResponse> GetAllUsers();
        Task<BaseResponse> GetSingleUser(string userID);

        Task<BaseResponse> DeleteUser(string userID);
        Task<BaseResponse> UpdateUser(User user);
        Task<BaseResponse> InsertUser(User user);
    }
}
