using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employeee.Data;
using Employeee.Models;

namespace Employeee.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly EmployeeeContext _context;

		public EmployeesController(EmployeeeContext context)
		{
			_context = context;
		}

		// GET: api/Employees
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
		{
			var employees = await _context.Employee.ToListAsync();
			if (employees == null || employees.Count == 0)
			{
				return NotFound();
			}
			return employees;
		}

		// GET: api/Employees/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Employee>> GetEmployee(int id)
		{
			var employee = await _context.Employee.FindAsync(id);
			if (employee == null)
			{
				return NotFound();
			}
			return employee;
		}

		// PUT: api/Employees/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEmployee(int id, Employee employee)
		{
			if (id != employee.Id)
			{
				return BadRequest();
			}

			_context.Entry(employee).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!EmployeeExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Employees
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
		{
			_context.Employee.Add(employee);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
		}

		// DELETE: api/Employees/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEmployee(int id)
		{
			var employee = await _context.Employee.FindAsync(id);
			if (employee == null)
			{
				return NotFound();
			}

			_context.Employee.Remove(employee);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool EmployeeExists(int id)
		{
			return _context.Employee.Any(e => e.Id == id);
		}

		// GET: api/employees/search?keyword=John
		[HttpGet("search")]
		public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployees(string keyword)
		{
			if (string.IsNullOrEmpty(keyword))
			{
				return BadRequest("Keyword cannot be empty");
			}

			var employees = await _context.Employee
				.Where(e => e.Name.Contains(keyword))
				.ToListAsync();

			if (employees == null || employees.Count() == 0)
			{
				return NotFound("No employees found matching the keyword");
			}

			return employees;
		}
	}
}
