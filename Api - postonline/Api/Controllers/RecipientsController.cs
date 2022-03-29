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
    public class RecipientsController : ControllerBase
    {
        private readonly ApiContext _context;

        public RecipientsController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Recipients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipient>>> GetRecipient()
        {
            return await _context.Recipient.ToListAsync();
        }

        // GET: api/Recipients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetRecipient(int id, bool singer = false)
        {
            if (!singer)
            {
                return await _context.Recipient.Where(i => i.UserID == id).ToListAsync();
            }else
            {
                var recipient = await _context.Recipient.FindAsync(id);

                if (recipient == null)
                {
                    return NotFound();
                }

                return recipient;
            }
            
        }

        // PUT: api/Recipients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipient(int id, Recipient recipient)
        {
            if (id != recipient.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipientExists(id))
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

        // POST: api/Recipients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipient>> PostRecipient(Recipient recipient)
        {
            _context.Recipient.Add(recipient);
            await _context.SaveChangesAsync();

            return Ok(new { Startus = "Done" });
        }

        // DELETE: api/Recipients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipient(int id)
        {
            var recipient = await _context.Recipient.FindAsync(id);
            if (recipient == null)
            {
                return NotFound();
            }

            _context.Recipient.Remove(recipient);
            await _context.SaveChangesAsync();

            return Ok(new { Startus = "Done" });
        }

        private bool RecipientExists(int id)
        {
            return _context.Recipient.Any(e => e.Id == id);
        }
    }
}
