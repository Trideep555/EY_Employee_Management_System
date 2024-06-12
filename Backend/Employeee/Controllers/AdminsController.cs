using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employeee.Data;
using Employeee.Models;

//namespace Employeee.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AdminsController : ControllerBase
//    {
//        private readonly EmployeeeContext _context;

//        public AdminsController(EmployeeeContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Admins
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmin()
//        {
//          if (_context.Admin == null)
//          {
//              return NotFound();
//          }
//            return await _context.Admin.ToListAsync();
//        }

//        // GET: api/Admins/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Admin>> GetAdmin(string id)
//        {
//          if (_context.Admin == null)
//          {
//              return NotFound();
//          }
//            var admin = await _context.Admin.FindAsync(id);

//            if (admin == null)
//            {
//                return NotFound();
//            }

//            return admin;
//        }

//        // PUT: api/Admins/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutAdmin(string id, Admin admin)
//        {
//            if (id != admin.Username)
//            {
//                return BadRequest();
//            }

//            _context.Entry(admin).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!AdminExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Admins
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
//        {
//          if (_context.Admin == null)
//          {
//              return Problem("Entity set 'EmployeeeContext.Admin'  is null.");
//          }
//            _context.Admin.Add(admin);
//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateException)
//            {
//                if (AdminExists(admin.Username))
//                {
//                    return Conflict();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return CreatedAtAction("GetAdmin", new { id = admin.Username }, admin);
//        }

//        // DELETE: api/Admins/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteAdmin(string id)
//        {
//            if (_context.Admin == null)
//            {
//                return NotFound();
//            }
//            var admin = await _context.Admin.FindAsync(id);
//            if (admin == null)
//            {
//                return NotFound();
//            }

//            _context.Admin.Remove(admin);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool AdminExists(string id)
//        {
//            return (_context.Admin?.Any(e => e.Username == id)).GetValueOrDefault();
//        }
//    }
//}



namespace EmployeeManagementSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private static Admin _admin = new Admin { Username = "admin", Password = "password" };

		// POST: api/auth/login
		[HttpPost("login")]
		public IActionResult Login([FromBody] Admin admin)
		{
			if (admin.Username == _admin.Username && admin.Password == _admin.Password)
			{
				return Ok();
			}
			return Unauthorized();
		}

		[HttpGet("user")]
        public IActionResult GetUser()
        {
            // Check if user is authenticated, for example using JWT or session
            // For demonstration purposes, assuming user is always authenticated after login
            return Ok(new { Username = _admin.Username, Password = _admin.Password });
        }
	}
}

