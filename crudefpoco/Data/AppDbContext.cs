using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudefpoco.Entities;
using Microsoft;
using Microsoft.EntityFrameworkCore;


namespace crudefpoco.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>();
    }
}
