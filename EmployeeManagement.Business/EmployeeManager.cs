using EmployeeManagement.Persistence.IRepository;
using EmployeeManagement.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Business
{
    public class EmployeeManager
    {
        private readonly IRepository<EmployeeMaster> _employeeMaster;

        public EmployeeManager(IRepository<EmployeeMaster> employeeMaster)
        {
            _employeeMaster = employeeMaster;
        }
        public void DeleteEmployeeMaster(EmployeeMaster employee)
        {
            _employeeMaster.Delete(employee);
        }

        public IEnumerable<EmployeeMaster> GetAllEmployeeMaster()
        {
            return _employeeMaster.GetAll();
        }


        public void CreateEmployeeMaster(EmployeeMaster employee)
        {
            _employeeMaster.Add(employee);
        }

        public void EditEmployeeMaster(EmployeeMaster employee)
        {
            
            _employeeMaster.Update(employee);
        }

        public EmployeeMaster GetEmployeeMasterById(int Id)
        {
            return _employeeMaster.GetById(Id);
        }

    }
}