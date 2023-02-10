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
    public class RaidsController : ControllerBase
    {
        private readonly Datasql _context;

        public RaidsController(Datasql context)
        {
            _context = context;
        }

        // GET: api/Raids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Raid>>> Getraid()
        {
            return await _context.raid.ToListAsync();
        }

        // GET: api/Raids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Raid>> GetRaid(int id)
        {
            var raid = await _context.raid.FindAsync(id);

            if (raid == null)
            {
                return NotFound();
            }

            return raid;
        }

        // PUT: api/Raids/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaid(int id, Raid raid)
        {
            if (id != raid.RaidId)
            {
                return BadRequest();
            }

            _context.Entry(raid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaidExists(id))
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

        // POST: api/Raids
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Raid>> PostRaid(Raid raid)
        {
            _context.raid.Add(raid);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRaid", new { id = raid.RaidId }, raid);
        }

        // DELETE: api/Raids/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaid(int id)
        {
            var raid = await _context.raid.FindAsync(id);
            if (raid == null)
            {
                return NotFound();
            }

            _context.raid.Remove(raid);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaidExists(int id)
        {
            return _context.raid.Any(e => e.RaidId == id);
        }
    }
}
