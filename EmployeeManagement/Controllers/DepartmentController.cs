using EmployeeManagement.Business;
using EmployeeManagement.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DepartmentController : ControllerBase
    {

        private readonly DepartmentManager _departmentManager;

        public DepartmentController(DepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllDepartmentMaster()
        {
            var response = _departmentManager.GetAllDepartmentMaster();
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public IActionResult GetDepartmentMasterById(int Id)
        {
            var response = _departmentManager.GetDepartmentMaster(Id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult EditDepartmentMaster(int id, DepartmentMaster department)
        {
            if (id != department.Id)
            {
                var failer = new Responce
                {
                    Status = "Failed to pass id",
                    Title = "Failed to Edit department",
                };

                return Ok(failer);
            }

            _departmentManager.EditDepartmentMaster(department);
            _departmentManager.Save();


            var response = new Responce
            {
                Status = "Success",
                Title = "Edited department",
            };
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateDepartmentMaster(DepartmentMaster department)
        {
            _departmentManager.CreateDepartmentMaster(department);
            _departmentManager.Save();

            var response = new Responce
            {
                Status = "Success",
                Title = "Create department",
            };
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartmentMaster(int id, DepartmentMaster department)
        {
            if (id != department.Id)
            {
                var failer = new Responce
                {
                    Status = "Failed to pass id",
                    Title = "Failed to Delete department",
                };

                return Ok(failer);
            }
            _departmentManager.DeleteDepartmentMaster(department);
            _departmentManager.Save();

            var response = new Responce
            {
                Status = "Success",
                Title = "Deleted department",
            };
            return Ok(response);
        }
    }
}

