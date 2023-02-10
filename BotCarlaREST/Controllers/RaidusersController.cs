using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BotCarlaREST.Models;

namespace BotCarlaREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaidusersController : ControllerBase
    {
        private readonly Datasql _context;

        public RaidusersController(Datasql context)
        {
            _context = context;
        }

        // GET: api/Raidusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Raiduser>>> GetRaiduser()
        {
            return await _context.Raiduser.ToListAsync();
        }

        // GET: api/Raidusers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Raiduser>> GetRaiduser(int id)
        {
            var raiduser = await _context.Raiduser.FindAsync(id);

            if (raiduser == null)
            {
                return NotFound();
            }

            return raiduser;
        }

        // PUT: api/Raidusers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaiduser(int id, Raiduser raiduser)
        {
            if (id != raiduser.UserDId)
            {
                return BadRequest();
            }

            _context.Entry(raiduser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaiduserExists(id))
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

        // POST: api/Raidusers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Raiduser>> PostRaiduser(Raiduser raiduser)
        {
            _context.Raiduser.Add(raiduser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRaiduser", new { id = raiduser.UserDId }, raiduser);
        }

        // DELETE: api/Raidusers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaiduser(int id)
        {
            var raiduser = await _context.Raiduser.FindAsync(id);
            if (raiduser == null)
            {
                return NotFound();
            }

            _context.Raiduser.Remove(raiduser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaiduserExists(int id)
        {
            return _context.Raiduser.Any(e => e.UserDId == id);
        }
    }
}
