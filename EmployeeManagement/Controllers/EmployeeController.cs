using EmployeeManagement.Business;
using EmployeeManagement.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeManager _employee;

        public EmployeeController(EmployeeManager employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public IActionResult GetAllEmployeeMaster()
        {
            var response = _employee.GetAllEmployeeMaster();
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetEmployeeById(int Id)
        {
            var response = _employee.GetEmployeeMasterById(Id);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult EditEmployeeMaster(EmployeeMaster employee)
        {
            _employee.EditEmployeeMaster(employee);
            var response = new Responce
            {
                Status = "Success",
                Title = "Edited Employee",
            };
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateEmployeeMaster(EmployeeMaster employee)
        {
            _employee.CreateEmployeeMaster(employee);
            var response = new Responce
            {
                Status = "Success",
                Title = "Create Employee",
            };
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult DeleteEmployeeMaster(EmployeeMaster employee)
        {
            _employee.DeleteEmployeeMaster(employee);
            var response = new Responce
            {
                Status = "Success",
                Title = "Deleted Employee",
            };
            return Ok(response);
        }
    }
}

