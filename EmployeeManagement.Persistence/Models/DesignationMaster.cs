using System;
using System.Collections.Generic;

namespace EmployeeManagement.Persistence.Models;

public partial class DesignationMaster
{
    public int Id { get; set; }

    public int? DepartmentId { get; set; }

    public string? DesignationName { get; set; }

    public virtual DepartmentMaster? Department { get; set; }

    public virtual ICollection<EmployeeMaster> EmployeeMasters { get; set; } = new List<EmployeeMaster>();

    public virtual ICollection<SalaryMaster> SalaryMasters { get; set; } = new List<SalaryMaster>();
}
