using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Almoxa.Models;

namespace API_Almoxa.Controllers
{
    [Route("api/saida")]
    [ApiController]
    public class SaidaEstoqueController : ControllerBase
    {
        private readonly almoxarifadobdContext _context;

        public SaidaEstoqueController(almoxarifadobdContext context)
        {
            _context = context;
        }

        // GET: api/SaidaEstoque
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaidaEstoque>>> GetSaidaEstoques()
        {
          if (_context.SaidaEstoques == null)
          {
              return NotFound();
          }
            return await _context.SaidaEstoques.ToListAsync();
        }

        // GET: api/SaidaEstoque/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaidaEstoque>> GetSaidaEstoque(int id)
        {
          if (_context.SaidaEstoques == null)
          {
              return NotFound();
          }
            var saidaEstoque = await _context.SaidaEstoques.FindAsync(id);

            if (saidaEstoque == null)
            {
                return NotFound();
            }

            return saidaEstoque;
        }

        // PUT: api/SaidaEstoque/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaidaEstoque(int id, SaidaEstoque saidaEstoque)
        {
            if (id != saidaEstoque.IdSaida)
            {
                return BadRequest();
            }

            _context.Entry(saidaEstoque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaidaEstoqueExists(id))
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

        // POST: api/SaidaEstoque
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SaidaEstoque>> PostSaidaEstoque(SaidaEstoque saidaEstoque)
        {
          if (_context.SaidaEstoques == null)
          {
              return Problem("Entity set 'almoxarifadobdContext.SaidaEstoques'  is null.");
          }
            _context.SaidaEstoques.Add(saidaEstoque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaidaEstoque", new { id = saidaEstoque.IdSaida }, saidaEstoque);
        }

        // DELETE: api/SaidaEstoque/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaidaEstoque(int id)
        {
            if (_context.SaidaEstoques == null)
            {
                return NotFound();
            }
            var saidaEstoque = await _context.SaidaEstoques.FindAsync(id);
            if (saidaEstoque == null)
            {
                return NotFound();
            }

            _context.SaidaEstoques.Remove(saidaEstoque);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaidaEstoqueExists(int id)
        {
            return (_context.SaidaEstoques?.Any(e => e.IdSaida == id)).GetValueOrDefault();
        }
    }
}
