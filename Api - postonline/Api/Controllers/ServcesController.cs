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
    public class ServcesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ServcesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Servces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servce>>> GetServce()
        {
            return await _context.Servce.ToListAsync();
        }

        // GET: api/Servces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servce>> GetServce(int id)
        {
            var servce = await _context.Servce.FindAsync(id);

            if (servce == null)
            {
                return NotFound();
            }

            return servce;
        }

        // PUT: api/Servces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServce(int id, Servce servce)
        {
            if (id != servce.Id)
            {
                return BadRequest();
            }

            _context.Entry(servce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServceExists(id))
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

        // POST: api/Servces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Servce>> PostServce(Servce servce)
        {
            _context.Servce.Add(servce);
            await _context.SaveChangesAsync();

            return Ok(new { Startus = "Done" });
        }

        // DELETE: api/Servces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServce(int id)
        {
            var servce = await _context.Servce.FindAsync(id);
            if (servce == null)
            {
                return NotFound();
            }

            _context.Servce.Remove(servce);
            await _context.SaveChangesAsync();

            return Ok(new { Startus = "Done" });
        }

        private bool ServceExists(int id)
        {
            return _context.Servce.Any(e => e.Id == id);
        }
    }
}
