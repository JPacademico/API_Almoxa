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
    [Route("api/entradas")]
    [ApiController]
    public class EntradaEstoqueController : ControllerBase
    {
        private readonly almoxarifadobdContext _context;

        public EntradaEstoqueController(almoxarifadobdContext context)
        {
            _context = context;
        }

        // GET: api/EntradaEstoque
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntradaEstoque>>> GetEntradaEstoques()
        {
          if (_context.EntradaEstoques == null)
          {
              return NotFound();
          }
            return await _context.EntradaEstoques.ToListAsync();
        }

        // GET: api/EntradaEstoque/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntradaEstoque>> GetEntradaEstoque(int id)
        {
          if (_context.EntradaEstoques == null)
          {
              return NotFound();
          }
            var entradaEstoque = await _context.EntradaEstoques.FindAsync(id);

            if (entradaEstoque == null)
            {
                return NotFound();
            }

            return entradaEstoque;
        }

        // PUT: api/EntradaEstoque/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntradaEstoque(int id, EntradaEstoque entradaEstoque)
        {
            if (id != entradaEstoque.IdEntrada)
            {
                return BadRequest();
            }

            _context.Entry(entradaEstoque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntradaEstoqueExists(id))
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

        // POST: api/EntradaEstoque
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntradaEstoque>> PostEntradaEstoque(EntradaEstoque entradaEstoque)
        {
          if (_context.EntradaEstoques == null)
          {
              return Problem("Entity set 'almoxarifadobdContext.EntradaEstoques'  is null.");
          }
            _context.EntradaEstoques.Add(entradaEstoque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntradaEstoque", new { id = entradaEstoque.IdEntrada }, entradaEstoque);
        }

        // DELETE: api/EntradaEstoque/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntradaEstoque(int id)
        {
            if (_context.EntradaEstoques == null)
            {
                return NotFound();
            }
            var entradaEstoque = await _context.EntradaEstoques.FindAsync(id);
            if (entradaEstoque == null)
            {
                return NotFound();
            }

            _context.EntradaEstoques.Remove(entradaEstoque);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntradaEstoqueExists(int id)
        {
            return (_context.EntradaEstoques?.Any(e => e.IdEntrada == id)).GetValueOrDefault();
        }
    }
}
