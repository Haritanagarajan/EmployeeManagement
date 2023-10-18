using System;
using System.Collections.Generic;

namespace EmployeeManagement.Persistence.Models;

public partial class SalaryMaster
{
    public int SalaryId { get; set; }

    public int? DepartmentId { get; set; }

    public int? DesignationId { get; set; }

    public int? BasicSalary { get; set; }

    public int? Benefits { get; set; }

    public int? Bonus { get; set; }

    public int? OtherAllowance { get; set; }

    public virtual DepartmentMaster? Department { get; set; }

    public virtual DesignationMaster? Designation { get; set; }
}
