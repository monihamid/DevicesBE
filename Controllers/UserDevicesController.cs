

using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevicesBE.Controllers
{
    [Route("api/devices/[controller]")]
    [ApiController]
    public class UserDeviceController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public UserDeviceController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/UserDevices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDevices>>> GetDevices()
        {
            return await _context.UserDevices.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<UserDevices>> PostUsers(UserDevices userDevices)
        {
            _context.UserDevices.Add(userDevices);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDevices), new { id = userDevices.Id }, userDevices);
        }
         // GET: api/devices/UserDevice/{UserId}
        [HttpGet("{UserId}")]
        public async Task<ActionResult<UserDevices>> GetDevices(int userId)
        {
            var device = await _context.UserDevices.FindAsync(userId);

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }
    }
}