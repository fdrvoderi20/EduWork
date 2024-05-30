using EduWork.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduWork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OvertimesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OvertimesController> _logger;

        public OvertimesController(ApplicationDbContext context, ILogger<OvertimesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetOvertimes()
        {
            var overtimes = await _context.Overtimes
                .Select(o => new
                {
                    o.OvertimeId,
                    o.Date,
                    o.Hours,
                    o.UserId
                })
                .ToListAsync();

            return Ok(overtimes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetOvertime(Guid id)
        {
            var overtime = await _context.Overtimes
                .Where(o => o.OvertimeId == id)
                .Select(o => new
                {
                    o.OvertimeId,
                    o.Date,
                    o.Hours,
                    o.UserId
                })
                .FirstOrDefaultAsync();

            if (overtime == null)
            {
                return NotFound();
            }

            return Ok(overtime);
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateOvertime(Overtime overtime)
        {
            _context.Overtimes.Add(overtime);
            await _context.SaveChangesAsync();

            var createdOvertime = new
            {
                overtime.OvertimeId,
                overtime.Date,
                overtime.Hours,
                overtime.UserId
            };

            return CreatedAtAction(nameof(GetOvertime), new { id = overtime.OvertimeId }, createdOvertime);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOvertime(Guid id, Overtime updatedOvertime)
        {
            if (id != updatedOvertime.OvertimeId)
            {
                return BadRequest();
            }

            _context.Entry(updatedOvertime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                if (!OvertimeExists(id))
                {
                    return NotFound();
                } else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOvertime(Guid id)
        {
            var overtime = await _context.Overtimes.FindAsync(id);
            if (overtime == null)
            {
                return NotFound();
            }

            _context.Overtimes.Remove(overtime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OvertimeExists(Guid id)
        {
            return _context.Overtimes.Any(e => e.OvertimeId == id);
        }
    }
}
