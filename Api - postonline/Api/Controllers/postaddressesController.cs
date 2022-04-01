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
    public class postaddressesController : ControllerBase
    {
        private readonly ApiContext _context;

        public postaddressesController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/postaddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<postaddress>>> Getpostaddress()
        {
            return await _context.postaddress.ToListAsync();
        }

        // GET: api/postaddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<postaddress>> Getpostaddress(int id)
        {
            var postaddress = await _context.postaddress.FindAsync(id);

            if (postaddress == null)
            {
                return NotFound();
            }

            return postaddress;
        }

        // PUT: api/postaddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpostaddress(int id, postaddress postaddress)
        {
            if (id != postaddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(postaddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!postaddressExists(id))
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

        // POST: api/postaddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<postaddress>> Postpostaddress(postaddress postaddress)
        {
            _context.postaddress.Add(postaddress);
            await _context.SaveChangesAsync();

            return Ok(new { Startus = "Done" });
        }

        // DELETE: api/postaddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepostaddress(int id)
        {
            var postaddress = await _context.postaddress.FindAsync(id);
            if (postaddress == null)
            {
                return NotFound();
            }

            _context.postaddress.Remove(postaddress);
            await _context.SaveChangesAsync();

            return Ok(new { Startus = "Done" });
        }

        private bool postaddressExists(int id)
        {
            return _context.postaddress.Any(e => e.Id == id);
        }
    }
}
