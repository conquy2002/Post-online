#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportFeesController : ControllerBase
    {
        private readonly ApiContext _context;

        public TransportFeesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/TransportFees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransportFee>>> GetTransportFee()
        {
            return await _context.TransportFee.ToListAsync();
        }

        // GET: api/TransportFees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransportFee>> GetTransportFee(int id)
        {
            var transportFee = await _context.TransportFee.FindAsync(id);

            if (transportFee == null)
            {
                return NotFound();
            }

            return transportFee;
        }

        // PUT: api/TransportFees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportFee(int id, TransportFee transportFee)
        {
            if (id != transportFee.Id)
            {
                return BadRequest();
            }

            _context.Entry(transportFee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportFeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { Startus = "Done" });
        }

        // POST: api/TransportFees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransportFee>> PostTransportFee(TransportFee transportFee)
        {
            _context.TransportFee.Add(transportFee);
            await _context.SaveChangesAsync();

            return Ok(new { Startus = "Done" });
        }

        // DELETE: api/TransportFees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransportFee(int id)
        {
            var transportFee = await _context.TransportFee.FindAsync(id);
            if (transportFee == null)
            {
                return NotFound();
            }

            _context.TransportFee.Remove(transportFee);
            await _context.SaveChangesAsync();

            return Ok(new { Startus = "Done" });
        }

        private bool TransportFeeExists(int id)
        {
            return _context.TransportFee.Any(e => e.Id == id);
        }
    }
}
