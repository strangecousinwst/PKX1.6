using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PKX.Data;
using PKX.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PKX.Controllers
{
    public class GMovimentos : Controller
    {
        private readonly ApplicationDbContext _context;

        public GMovimentos(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchText, int? clienteId, bool showAll = false)
        {
            var clientes = _context.Clientes != null ? await _context.Clientes.ToListAsync() : new List<Cliente>();
            var tiposMovimento = _context.TiposMovimentos != null ? await _context.TiposMovimentos.ToListAsync() : new List<TipoMovimento>();

            var filteredClientes = string.IsNullOrEmpty(searchText)
                ? clientes
                : clientes.Where(c => c.NomeCliente != null && c.NomeCliente.Contains(searchText, System.StringComparison.OrdinalIgnoreCase)).ToList();

            List<Movimento> clienteMovimentos;
            if (showAll)
            {
                clienteMovimentos = await _context.Movimentos.ToListAsync();
            }
            else
            {
                clienteMovimentos = clienteId.HasValue
                    ? await _context.Movimentos.Where(m => m.ClienteId == clienteId.Value).ToListAsync()
                    : new List<Movimento>();
            }

            ViewBag.Clientes = filteredClientes;
            ViewBag.Movimentos = clienteMovimentos;
            return View(clienteMovimentos);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimento = await _context.Movimentos.FindAsync(id);
            if (movimento == null)
            {
                return NotFound();
            }
            return View(movimento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Descritivo,Valor,TipoId,ClienteId,Marcador")] Movimento movimento)
        {
            if (id != movimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentoExists(movimento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movimento);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimento = await _context.Movimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimento == null)
            {
                return NotFound();
            }

            return View(movimento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimento = await _context.Movimentos.FindAsync(id);
            _context.Movimentos.Remove(movimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentoExists(int id)
        {
            return _context.Movimentos.Any(e => e.Id == id);
        }
    }
}
