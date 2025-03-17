using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PKX.Data;
using PKX.Models;

namespace PKX.Controllers
{
    public class GProcessosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GProcessosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GProcessos
        public async Task<IActionResult> Index()

        {
            CarregaProcessos();
            return View();
        }
        public void CarregaProcessos()
        {
            List<Processo> processos = _context.Processos.ToList();

            ViewBag.PROCESSOS = new SelectList(processos, "Id", "Titulo");
        }

        public async Task<IActionResult> MostrarLinhas(int? processo)
        {
            var lp = (from p in _context.LinhasProcessos    
                      join f in _context.Funcionarios on p.FuncionarioId equals f.Id
                      where p.ProcessoId == processo
                      select new
                      {
                          Id = p.Id,
                          Data = p.Data,
                          Texto = p.Texto,
                          ProcessoId = p.ProcessoId,
                          FuncionarioId = f.NomeFuncionario
                      }).ToList();
            ViewBag.LINHAPROCESSOS = lp;
            CarregaProcessos();
            return View("Index");
        }





































        // GET: GProcessos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaProcesso = await _context.LinhasProcessos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linhaProcesso == null)
            {
                return NotFound();
            }

            return View(linhaProcesso);
        }

        // GET: GProcessos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GProcessos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Texto,ProcessoId,FuncionarioId")] LinhaProcesso linhaProcesso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linhaProcesso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(linhaProcesso);
        }

        // GET: GProcessos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaProcesso = await _context.LinhasProcessos.FindAsync(id);
            if (linhaProcesso == null)
            {
                return NotFound();
            }
            return View(linhaProcesso);
        }

        // POST: GProcessos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Texto,ProcessoId,FuncionarioId")] LinhaProcesso linhaProcesso)
        {
            if (id != linhaProcesso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linhaProcesso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinhaProcessoExists(linhaProcesso.Id))
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
            return View(linhaProcesso);
        }

        // GET: GProcessos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaProcesso = await _context.LinhasProcessos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linhaProcesso == null)
            {
                return NotFound();
            }

            return View(linhaProcesso);
        }

        // POST: GProcessos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var linhaProcesso = await _context.LinhasProcessos.FindAsync(id);
            if (linhaProcesso != null)
            {
                _context.LinhasProcessos.Remove(linhaProcesso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinhaProcessoExists(int id)
        {
            return _context.LinhasProcessos.Any(e => e.Id == id);
        }
    }
}
