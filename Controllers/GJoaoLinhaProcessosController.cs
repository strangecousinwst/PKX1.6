﻿using System;
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
    public class GJoaoLinhaProcessosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GJoaoLinhaProcessosController(ApplicationDbContext context)
        {
            _context = context;
        }

         // metodo que devolve linhas de processo com determinado ID de processo
        public async Task<IActionResult> FiltrarPorProcessosId(int? id) {
            if (id == null) {
                return NotFound();
            }

            var linhasProcessos = await _context.LinhasProcessos
                                                .Where(p => p.ProcessoId == id)
                                                .ToListAsync();

            if (linhasProcessos == null) {
                return NotFound();
            }

            return View(linhasProcessos);
        }

        // metodo que devolve processos com determinado ID de cliente
        public async Task<IActionResult> FiltrarPorClienteId(int? id) {
            if (id == null) {
                return NotFound();
            }

            var listaProcessos = await _context.Processos
                                         .Where(p => p.ClienteId == id)
                                         .ToListAsync();            

            if (listaProcessos == null) {
                return NotFound();
            }

            return View(listaProcessos);
        }

        // metodo que devolve processos com determinado ID de prioridade
        public async Task<IActionResult> FiltrarPorPrioridadeId(int? id) {
            if (id == null) {
                return NotFound();
            }

            var listaProcessos = await _context.Processos
                                               .Where(p => p.TipoPrioridadeId == id)
                                               .ToListAsync();

            if (listaProcessos == null) {
                return NotFound();
            }

            return View(listaProcessos);
        }

        // metodo que devolve processos com determinado ID de categoria
        public async Task<IActionResult> FiltrarPorCategoriasId(int? id) {
            if (id == null) {
                return NotFound();
            }

            var listaProcessos = await _context.Processos
                                               .Where(p => p.CategoriaId == id)
                                               .ToListAsync();

            if (listaProcessos == null) {
                return NotFound();
            }

            return View(listaProcessos);
        }

        // metodo que devolve processos com determinado ID de estado
        public async Task<IActionResult> FiltrarPorEstadoId(int? id) {
            if (id == null) {
                return NotFound();
            }

            var listaProcessos = await _context.Processos
                                               .Where(p => p.EstadoId == id)
                                               .ToListAsync();

            if (listaProcessos == null) {
                return NotFound();
            }

            return View(listaProcessos);
        }

        // metodo que devolve processos com coima
        public async Task<IActionResult> GetProcessosComCoima() {

            var listaProcessos = await _context.Processos
                                               .Where(p => p.TemCoima == true)
                                               .ToListAsync();

            if (listaProcessos == null) {
                return NotFound();
            }

            return View(listaProcessos);
        }

        // GET: GJoaoLinhaProcessos
        public async Task<IActionResult> Index()
        {
            return View(await _context.LinhasProcessos.ToListAsync());
        }

        // GET: GJoaoLinhaProcessos/Details/5
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

        // GET: GJoaoLinhaProcessos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GJoaoLinhaProcessos/Create
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

        // GET: GJoaoLinhaProcessos/Edit/5
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

        // POST: GJoaoLinhaProcessos/Edit/5
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

        // GET: GJoaoLinhaProcessos/Delete/5
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

        // POST: GJoaoLinhaProcessos/Delete/5
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
