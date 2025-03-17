using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PKX.Data;
using PKX.Models;

namespace PKX.Controllers
{
    public class GCadastrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GCadastrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cadastros
        public async Task<IActionResult> Index(DateTime? dataInicial, DateTime? dataFinal, int? clienteId, string clienteNome, string data)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity DbContext.Clientes esta nula.");
            }

            var cadastros = _context.Cadastros
              //  .Include(c => c.Cliente)
                .ToList();

            if (dataInicial.HasValue)
            {
                cadastros = cadastros?.Where(c => c.Data >= dataInicial.Value).ToList();
            }

            if (dataFinal.HasValue)
            {
                cadastros = cadastros?.Where(c => c.Data <= dataFinal.Value).ToList();
            }

            if (clienteId.HasValue && clienteId.Value > 0)
            {
                cadastros = cadastros?.Where(c => c.ClienteId == clienteId.Value).ToList();
            }
            if (clienteId.HasValue && clienteId.Value > 0)
            {
                cadastros = cadastros?.Where(c => c.ClienteId == clienteId.Value).ToList();
            }

            var clientes = await _context.Clientes.OrderBy(c => c.NomeCliente).ToListAsync();

            if (clienteNome != null)
            {
                clientes = clientes.Where(c => c.NomeCliente != null && c.NomeCliente.Contains(clienteNome)).OrderBy(c => c.NomeCliente).ToList();
            }

            // ############################################################################################################################################ Data



            if (data == "asc")
            {  
                cadastros = _context.Cadastros.OrderBy(c => c.Data).ToList();
                ViewBag.ORDENARDATA = "desc";
            }
            else if (data == "desc")
            {
                cadastros = _context.Cadastros.OrderByDescending(c => c.Data).ToList();
                ViewBag.ORDENARDATA = "asc"; 
            }
            else
            {
                //cadastros = _context.Cadastros
                //            .Include(c => c.Cliente)
                //            .ToList();
                //ViewBag.ORDENARDATA = "asc";
            }

            ViewBag.Clientes = new SelectList(clientes, "Id", "NomeCliente");
            return View(cadastros.ToList());
        }

        // GET: Cadastros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros
            //    .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // GET: Cadastros/Create
        public IActionResult Create()
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity DbContext.Clientes está nula.");
            }

            ViewBag.Clientes = new SelectList(_context.Clientes, "Id", "NomeCliente");
            return View();
        }

        // POST: Cadastros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Texto,ClienteId")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //código para depuração
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }


            ViewBag.Clientes = new SelectList(_context.Clientes, "Id", "NomeCliente", cadastro.ClienteId);
            return View(cadastro);
        }

        // GET: Cadastros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }

            ViewBag.Clientes = new SelectList(_context.Clientes, "Id", "NomeCliente", cadastro.ClienteId);
            return View(cadastro);
        }

        // POST: Cadastros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Texto,ClienteId")] Cadastro cadastro)
        {
            if (id != cadastro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroExists(cadastro.Id))
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
            ViewBag.Clientes = new SelectList(_context.Clientes, "Id", "NomeCliente", cadastro.ClienteId);
            return View(cadastro);
        }

        // GET: Cadastros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // POST: Cadastros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastro = await _context.Cadastros.FindAsync(id);
            if (cadastro != null)
            {
                _context.Cadastros.Remove(cadastro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroExists(int id)
        {
            return _context.Cadastros.Any(e => e.Id == id);
        }
    }
}



