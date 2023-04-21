using Employee.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.Interfaces
{
    public interface ISL_City_Repository
    {
        Task<BaseResponse> GetAllCities();
    }
}
