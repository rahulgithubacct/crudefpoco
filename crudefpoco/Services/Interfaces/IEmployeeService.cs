using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudefpoco.DTOs.Employee;

namespace crudefpoco.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync();

        Task<EmployeeDto?> GetByIdAsync(int id);

        Task<int> CreateAsync(CreateEmployeeDto dto);

        Task UpdateAsync(int id, UpdateEmployeeDto dto);

        Task DeleteAsync(int id);
    }
}
