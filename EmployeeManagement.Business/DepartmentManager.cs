using EmployeeManagement.Persistence.IRepository;
using EmployeeManagement.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Business
{
    public class DepartmentManager
    {
        private readonly IRepository<DepartmentMaster> _departmentMaster;

        public DepartmentManager(IRepository<DepartmentMaster> departmentMaster)
        {
            _departmentMaster = departmentMaster;
        }
        public void DeleteDepartmentMaster(DepartmentMaster department)
        {
            _departmentMaster.Delete(department);
        }

        public IEnumerable<DepartmentMaster> GetAllDepartmentMaster()
        {
            return _departmentMaster.GetAll();
        }


        public void CreateDepartmentMaster(DepartmentMaster department)
        {
            _departmentMaster.Add(department);
        }

        public void EditDepartmentMaster(DepartmentMaster department)
        {

            _departmentMaster.Update(department);
        }

        public DepartmentMaster GetDepartmentMaster(int Id)
        {
            return _departmentMaster.GetById(Id);
        }

    }
}
