using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Models
{
    public class LoginTokenDetails
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }

    }
}
