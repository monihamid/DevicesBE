using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
//using Models;

namespace DevicesBE.Controllers
{
    [Route("api/devices/[controller]")]
    [ApiController]
    public class AddUserController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public AddUserController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/device/adduser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        // POST: api/device/adduser
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUsers", new { id = users.Id }, users);
            return CreatedAtAction(nameof(GetUsers), new { id = users.Id }, users);
        }

    }
}
