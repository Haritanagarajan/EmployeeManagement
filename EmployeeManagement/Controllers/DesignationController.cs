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
    public class DesignationController : ControllerBase
    {

        private readonly DesignationManager _designationManager;

        public DesignationController(DesignationManager designationManager)
        {
            _designationManager = designationManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllDesignationMaster()
        {
            var response = _designationManager.GetAllDesignationMaster();
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public IActionResult GetDesignationMasterById(int Id)
        {
            var response = _designationManager.GetDesignationMaster(Id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult EditDesignationMaster(int id, DesignationMaster designation)
        {
            if (id != designation.Id)
            {
                var failer = new Responce
                {
                    Status = "Failed to pass id",
                    Title = "Failed to Edit designation",
                };

                return Ok(failer);
            }

            _designationManager.EditDesignationMaster(designation);
            _designationManager.Save();


            var response = new Responce
            {
                Status = "Success",
                Title = "Edited designation",
            };
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateDesignationMaster(DesignationMaster designation)
        {
            _designationManager.CreateDesignationMaster(designation);
            _designationManager.Save();

            var response = new Responce
            {
                Status = "Success",
                Title = "Create designation",
            };
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDesignationMaster(int id, DesignationMaster designation)
        {
            if (id != designation.Id)
            {
                var failer = new Responce
                {
                    Status = "Failed to pass id",
                    Title = "Failed to Delete designation",
                };

                return Ok(failer);
            }
            _designationManager.DeleteDesignationMaster(designation);
            _designationManager.Save();

            var response = new Responce
            {
                Status = "Success",
                Title = "Deleted designation",
            };
            return Ok(response);
        }
    }
}

