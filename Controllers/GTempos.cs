using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PKX.Data;
using PKX.Models;

namespace PKX.Controllers
{
    public class GTempos : Controller
    {
        private readonly ApplicationDbContext _context;

        public GTempos(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tempos
        [HttpGet]
        public IActionResult Index(int AtividadeId, int FuncionarioId, int ClienteId, string sortedBy, bool isAsc)
        {

            ViewBag.Atividades = GTemposUtils.BuildSelectList(_context.Atividades, "Designacao");
            ViewBag.Funcionarios = GTemposUtils.BuildSelectList(_context.Funcionarios, "NomeFuncionario");
            ViewBag.Clientes = GTemposUtils.BuildSelectList(_context.Clientes, "NomeCliente");

            ViewBag.SortedBy = sortedBy;
            ViewBag.isAsc = isAsc;

            ViewBag.listaTempo = GTemposUtils.GetFilteredTemposQuery(_context, AtividadeId, FuncionarioId, ClienteId, sortedBy, isAsc).ToList();            
            return View();
        }

        // GET: Tempos/Create
        public IActionResult Create()
        {
            ViewBag.Atividades = GTemposUtils.BuildSelectList(_context.Atividades, "Designacao");
            ViewBag.Funcionarios = GTemposUtils.BuildSelectList(_context.Funcionarios, "NomeFuncionario");
            ViewBag.Clientes = GTemposUtils.BuildSelectList(_context.Clientes, "NomeCliente");

            return View();
        }

        // POST: Tempos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Descritivo,Minutos,AtividadeId,FuncionarioId,ClienteId")] Tempo tempo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tempo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tempo);
        }

    }
}
