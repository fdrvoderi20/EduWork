using EduWork.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;

namespace EduWork.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
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
        public async Task<ActionResult<IEnumerable<Overtime>>> GetOvertimes()
        {
            var overtimes = await _context.Overtimes.ToListAsync();
            return Ok(overtimes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Overtime>> GetOvertime(Guid id)
        {
            var overtime = await _context.Overtimes.FindAsync(id);

            if (overtime == null)
            {
                return NotFound();
            }

            return Ok(overtime);
        }

        [HttpPost]
        public async Task<ActionResult<Overtime>> CreateOvertime(Overtime overtime)
        {
            _context.Overtimes.Add(overtime);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOvertime), new { id = overtime.OvertimeId }, overtime);
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
