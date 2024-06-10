using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Employeee.Models;

namespace Employeee.Data
{
    public class EmployeeeContext : DbContext
    {
        public EmployeeeContext (DbContextOptions<EmployeeeContext> options)
            : base(options)
        {
        }

        public DbSet<Employeee.Models.Employee> Employee { get; set; } = default!;

        public DbSet<Employeee.Models.Admin> Admin { get; set; } = default!;
    }
}
