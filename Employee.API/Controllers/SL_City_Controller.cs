using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Employee.API.Controllers
{
    [Route("api/TestProject/[controller]")]
    [ApiController]
    public class SL_City_Controller : Controller
    {
        ISL_City_Repository _repository;
        public IActionResult Index()
        {
            return View();
        }
        public SL_City_Controller(ISL_City_Repository repository)
        {
            _repository = repository;
        }

        //Get All Cities
        [HttpGet("GetAllCity")]
        public async Task<ActionResult> GetAllUsers()
        {
            var response = await _repository.GetAllCities();

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
