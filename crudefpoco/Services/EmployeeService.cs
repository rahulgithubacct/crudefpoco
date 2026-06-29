using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudefpoco.Data;
using crudefpoco.DTOs.Employee;
using crudefpoco.Entities;
using crudefpoco.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace crudefpoco.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                CreatedDate = System.DateTime.UtcNow
            };

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            return employee.Id;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            return await _context.Employees
                .AsNoTracking()
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email
                })
                .ToListAsync();
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Where(x => x.Id == id)
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email
                })
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(
    int id,
    UpdateEmployeeDto dto)
        {
            var employee =
                await _context.Employees.FindAsync(id);

            if (employee == null)
                throw new System.Exception("Employee not found");

            employee.Name = dto.Name;
            employee.Email = dto.Email;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var employee =
                await _context.Employees.FindAsync(id);

            if (employee == null)
                throw new System.Exception("Employee not found");

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();
        }
    }

}
