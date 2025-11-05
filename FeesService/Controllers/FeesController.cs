using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeesService.Data;
using FeesService.Models;

namespace FeesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeesController : ControllerBase
    {
        private readonly FeesDbContext _context;

        public FeesController(FeesDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/fees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fee>>> GetFees()
        {
            return await _context.Fees.ToListAsync();
        }

        // ✅ GET: api/fees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fee>> GetFee(int id)
        {
            var fee = await _context.Fees.FindAsync(id);
            if (fee == null)
                return NotFound();

            return fee;
        }

        // ✅ POST: api/fees
        [HttpPost]
        public async Task<ActionResult<Fee>> CreateFee(Fee fee)
        {
            _context.Fees.Add(fee);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFee), new { id = fee.Id }, fee);
        }

        // ✅ PUT: api/fees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFee(int id, Fee fee)
        {
            if (id != fee.Id)
                return BadRequest();

            _context.Entry(fee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // ✅ DELETE: api/fees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFee(int id)
        {
            var fee = await _context.Fees.FindAsync(id);
            if (fee == null)
                return NotFound();

            _context.Fees.Remove(fee);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
