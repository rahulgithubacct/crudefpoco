using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using crudefpoco.Services.Interfaces;
using crudefpoco.DTOs.Employee;

namespace crudefpoco.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult>Create(CreateEmployeeDto dto)
        {
            
            var id = await _service.CreateAsync(dto);

            return Ok(id);
        }
    }
}
