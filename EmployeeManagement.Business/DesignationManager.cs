using EmployeeManagement.Persistence.IRepository;
using EmployeeManagement.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Business
{
    public class DesignationManager
    {
        private readonly IRepository<DesignationMaster> _designation;

        public DesignationManager(IRepository<DesignationMaster> designation)
        {
            _designation = designation;
        }
        public void DeleteDesignationMaster(DesignationMaster designation)
        {
            _designation.Delete(designation);
        }

        public IEnumerable<DesignationMaster> GetAllDesignationMaster()
        {
            return _designation.GetAll();
        }


        public void CreateDesignationMaster(DesignationMaster designation)
        {
            _designation.Add(designation);
        }

        public void EditDesignationMaster(DesignationMaster designation)
        {

            _designation.Update(designation);
        }

        public DesignationMaster GetDesignationMaster(int Id)
        {
            return _designation.GetById(Id);
        }
    }
}
