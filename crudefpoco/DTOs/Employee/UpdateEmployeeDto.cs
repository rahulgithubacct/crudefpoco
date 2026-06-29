using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudefpoco.DTOs.Employee
{
    public class UpdateEmployeeDto
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
