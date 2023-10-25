using EmployeeManagement.Business;
using EmployeeManagement.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeManager _employee;

        public EmployeeController(EmployeeManager employee)
        {
            _employee = employee;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllEmployeeMaster()
        {
            var response = _employee.GetAllEmployeeMaster();
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [Authorize(Roles = "Employee,Admin")]
        public IActionResult GetEmployeeById(int Id)
        {
            var response = _employee.GetEmployeeMasterById(Id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Employee")]
        public IActionResult EditEmployeeMaster(int id, [FromBody]EmployeeMaster employee)
        {
            if (id != employee.Id)
            {
                var failer = new Responce
                {
                    Status = "Failed to pass id",
                    Title = "Failed to Edit Employee",
                };

                return Ok(failer);
            }

            _employee.EditEmployeeMaster(employee);

            var response = new Responce
            {
                Status = "Success",
                Title = "Edited Employee",
            };
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public IActionResult DeleteEmployeeMaster(int id, [FromBody]EmployeeMaster employee)
        {
            if (id != employee.Id)
            {
                var failer = new Responce
                {
                    Status = "Failed to pass id",
                    Title = "Failed to Delete Employee",
                };

                return Ok(failer);
            }
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

