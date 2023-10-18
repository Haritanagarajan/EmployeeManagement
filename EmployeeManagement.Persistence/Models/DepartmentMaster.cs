using System;
using System.Collections.Generic;

namespace EmployeeManagement.Persistence.Models;

public partial class DepartmentMaster
{
    public int DepartmentId { get; set; }

    public string? Departmentname { get; set; }

    public virtual ICollection<DesignationMaster> DesignationMasters { get; set; } = new List<DesignationMaster>();

    public virtual ICollection<EmployeeMaster> EmployeeMasters { get; set; } = new List<EmployeeMaster>();

    public virtual ICollection<SalaryMaster> SalaryMasters { get; set; } = new List<SalaryMaster>();
}
