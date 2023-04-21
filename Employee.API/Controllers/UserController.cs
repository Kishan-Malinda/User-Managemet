using Employee.Models.Models;
using Employee.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Controllers
{
    [Route("api/TestProject/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserRepository _repository;
        public IActionResult Index()
        {
            return View();
        }
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        //Get All Users
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAllUsers()
        {
            var response = await _repository.GetAllUsers();

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        // Get Single User
        [HttpGet("GetById")]
        public async Task<ActionResult> GetSingleUser(string userID) 
        {
            var response = await _repository.GetSingleUser(userID);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        // Delete User
        [HttpDelete("Delete")]
        public  async Task<ActionResult> DeleteUser(string userID)
        {
            var response = await _repository.DeleteUser(userID);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        // Insert User
        [HttpPost("AddUser")]
        public async Task<ActionResult> InsertUser(User user)
        {
            var response = await _repository.InsertUser(user);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        //Update User
        [HttpPut("Update")]
        public async Task<ActionResult> UpdateUser([FromBody] User user) 
        {
            var response = await _repository.UpdateUser(user);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
