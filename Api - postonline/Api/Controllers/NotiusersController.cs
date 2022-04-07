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
    public class NotiusersController : ControllerBase
    {
        private readonly ApiContext _context;

        public NotiusersController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Notiusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notiuser>>> GetNotiuser()
        {
            return await _context.Notiuser.ToListAsync();
        }

        // GET: api/Notiusers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notiuser>> GetNotiuser(int id,int? userid , int start = 0 , int end = 10000)
        {
            var notiuser = await _context.Notiuser.FindAsync(id);
            if (userid != null)
            {
                var user = await _context.User.FindAsync(userid);
                if(user == null)
                {
                    return NotFound();
                }
                else
                {
                    var notiall = _context.Notiuser.Where(i => i.UserId == userid).OrderBy(a => a.Id).Skip(start).Take(end);
                    return Ok(notiall);
                }
            }

            if (notiuser == null)
            {
                return NotFound();
            }

            return notiuser;
        }

        // PUT: api/Notiusers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotiuser(int id, Notiuser notiuser)
        {
            if (id != notiuser.Id)
            {
                return BadRequest();
            }

            _context.Entry(notiuser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotiuserExists(id))
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

        // POST: api/Notiusers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Notiuser>> PostNotiuser(Notiuser notiuser)
        {
            _context.Notiuser.Add(notiuser);
            await _context.SaveChangesAsync();

            return Ok(new { Startus = "Done" });
        }

        // DELETE: api/Notiusers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotiuser(int id)
        {
            var notiuser = await _context.Notiuser.FindAsync(id);
            if (notiuser == null)
            {
                return NotFound();
            }

            _context.Notiuser.Remove(notiuser);
            await _context.SaveChangesAsync();

            return Ok(new { Startus = "Done" });
        }

        private bool NotiuserExists(int id)
        {
            return _context.Notiuser.Any(e => e.Id == id);
        }
    }
}
