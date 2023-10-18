using System;
using System.Collections.Generic;

namespace EmployeeManagement.Persistence.Models;

public partial class EmployeeMaster
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public long? MobileNumber { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public int? ZipCode { get; set; }

    public DateTime? HireDate { get; set; }

    public bool? IsActive { get; set; }

    public int? DepartmentId { get; set; }

    public int? DesignationId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual DepartmentMaster? Department { get; set; }

    public virtual DesignationMaster? Designation { get; set; }
}
