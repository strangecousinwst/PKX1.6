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
        // variavel que permite a conexao a BD
        private readonly ApplicationDbContext _context;

        // construtor que permite a inicializacao da variavel _context
        public GProcessosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GProcessos
        public IActionResult Index()

        {
            // inicialização da variavel de sessão para informação quando estão ativos os filtros que permitem filtrar os processos apresentados na view index
            // false representa que não estão ativos
            HttpContext.Session.SetString("FiltrosAtivos", false.ToString());

            // inicialização da variavel de sessão para informar se já foi escolhido um cliente
            // o '0' representa que não foi ainda selecionado nenhum cliente
            HttpContext.Session.SetInt32("FiltroCliente", 0);

            // inicialização da variavel de sessão para informar se já foi escolhido um processo
            // o '0' representa que não foi ainda selecionado nenhum processo
            HttpContext.Session.SetInt32("FiltroProcesso", 0);

            // metodo que carrega os processos para a view index, caso contrario nao aparecem os processos na DropDownList processos da view index
            CarregarProcessosFiltrados();

            return View();
        }


        // Metodo que carrega os processos FILTRADOS para a view index, caso contrario haveriam processos na respetiva DropDownList da view index
        [HttpPost]
        public IActionResult CarregarProcessosFiltrados()
        {
            int cliente = HttpContext.Session.GetInt32("FiltroCliente") ?? 0;
            
            // carrega os processos para a lista processos filtrado pelo cliente
            List<Processo> processos = _context.Processos
                                        .Where(p =>  cliente > 0 && cliente != null ?  p.ClienteId == cliente : 1==1 )
                                        .ToList();

            // recupero o valor do FiltroProcesso que estava selecionado de modo a passar como selecionado na DropDownList
            int filtroProcesso = HttpContext.Session.GetInt32("FiltroProcesso") ?? 0;

            // devolve os processos e suas quantidade para a view index atraves da ViewBag.PROCESSOS, com recurso a SelectList para devolver o Id e o Titulo do processo
            ViewBag.processos = new SelectList(processos, "Id", "Titulo", filtroProcesso);
                     

            // atualzia a ViewBag.QUANTIDADEPROCESSOS com a quantidade de processos
            ViewBag.QUANTIDADEPROCESSOS = processos.Count();


            // recupero o valor de sessão que contem informação sobre se os filtros estão ativos de modo a saber se é necessario carregar as combos de filtragem
            bool filtrosAtivos = bool.Parse(HttpContext.Session.GetString("FiltrosAtivos"));
            if (filtrosAtivos) 
            {
                CarregarClientes();
            }

            return View("Index");
        }

        
        // Metodo que carrega os clientes para a view index, caso contrario haveriam clientes na respetiva DropDownList da view index
        public void CarregarClientes()
        {
            // carrega os processos para a lista clientes
            List<Cliente> clientes = _context.Clientes.ToList();

            int filtroCliente = HttpContext.Session.GetInt32("FiltroCliente") ?? 0;

            // devolve os processos e suas quantidade para a view index atraves da ViewBag.PROCESSOS, com recurso a SelectList para devolver o Id e o Titulo do processo
            ViewBag.cliente = new SelectList(clientes, "Id", "NomeCliente", filtroCliente);

             View("Index");
        }


        // Metodo que altera o filtro cliente
        public IActionResult AlterarFiltroCliente(int? cliente)
        {
            // atualização da variavel de sessão para informação de quando estão ativos os filtros que permitem filtrar os processos apresentados na view index
            HttpContext.Session.SetInt32("FiltroCliente", cliente ?? 0);
            // atualização da variavel de sessão para informação de quando estão ativos os filtros que permitem filtrar os processos apresentados na view index
            HttpContext.Session.SetInt32("FiltroProcesso", 0);

            // recuperar o valor do processo que estava selecionado
            int filtroProcesso = HttpContext.Session.GetInt32("FiltroProcesso") ?? 0;

            // permite saber se o utilizador já estava a ver linhas de um processo
            if (filtroProcesso > 0)
            {
                MostrarLinhas(filtroProcesso);
            }
            else
            {
                CarregarProcessosFiltrados();
            }

            return View("Index");
        }


        // Metodo que ativa a flag para filtrar os processos
        public IActionResult ExibirFiltros()
        {
            // atualização da variavel de sessão para informação de quando estão ativos os filtros que permitem filtrar os processos apresentados na view index
            HttpContext.Session.SetString("FiltrosAtivos", true.ToString());

            // recuperar o valor do processo que estava selecionado
            int filtroProcesso = HttpContext.Session.GetInt32("FiltroProcesso") ?? 0;


            // permite saber se o utilizador já estava a ver linhas de um processo
            if (filtroProcesso > 0)
            {
                MostrarLinhas(filtroProcesso);
            }
            else
            {
                CarregarProcessosFiltrados();
            }

            return View("Index");
        }


        public IActionResult LimparFiltros()
        {
            // atualização da variavel de sessão para informação de quando estão ativos os filtros que permitem filtrar os processos apresentados na view index
            HttpContext.Session.SetInt32("FiltroCliente", 0);

            // recuperar o valor do processo que estava selecionado
            int filtroProcesso = HttpContext.Session.GetInt32("FiltroProcesso") ?? 0;


            // permite saber se o utilizador já estava a ver linhas de um processo
            if (filtroProcesso > 0)
            {
                MostrarLinhas(filtroProcesso);
            }
            else
            {
                CarregarProcessosFiltrados();
            }

            return View("Index");
        }


        // Metodo que desativa a flag para filtrar os processos

        public IActionResult RemoverFiltros()
        {
            // atualização da variavel de sessão para informação de quando estão ativos os filtros que permitem filtrar os processos apresentados na view index
            HttpContext.Session.SetString("FiltrosAtivos", false.ToString());

            // recuperar o valor do processo que estava selecionado
            int filtroProcesso = HttpContext.Session.GetInt32("FiltroProcesso") ?? 0;


            // permite saber se o utilizador já estava a ver linhas de um processo
            if (filtroProcesso > 0)
            {
                MostrarLinhas(filtroProcesso);
            }
            else
            {
                CarregarProcessosFiltrados();
            }


            return View("Index");
        }


        // Metodo que devolve as linhas de um processo
        [HttpPost]
        public IActionResult MostrarLinhas(int? processo)
        {
            // atualização da variavel de sessão que informa se já foi escolhido um processo
            if (processo == null)
            {
                HttpContext.Session.SetInt32("FiltroProcesso", 0);
                processo = 0;
            }
            else
            {
                HttpContext.Session.SetInt32("FiltroProcesso", processo.Value);
            }
            

            // se o processo for nulo, devolve a view index
            if (processo != null)
            {

                // se o processo for diferente de nulo, devolve as linhas do processo
                var linhasProcesso = (from lp in _context.LinhasProcessos // consulta LINQ que devolve as linhas de um processo
                                      join p in _context.Processos on lp.ProcessoId equals p.Id // junta a tabela Processos com a tabela LinhasProcessos
                                      join f in _context.Funcionarios on lp.FuncionarioId equals f.Id // junta a tabela Funcionarios com a tabela LinhasProcessos
                                      where lp.ProcessoId == processo // onde o id do processo for igual ao id do processo
                                      select new // devolve um objeto anonimo com os campos Id, Data, Texto, ProcessoId e FuncionarioId
                                      {
                                          Id = lp.Id, // id da linha de processo
                                          Data = lp.Data, // data da linha de processo
                                          Texto = lp.Texto, // texto da linha de processo
                                          Titulo = p.Titulo, // titulo do processo
                                          FuncionarioId = f.NomeFuncionario // nome do funcionario
                                      }).ToList();
                // devolve as linhas do processo para a view index atraves da ViewBag.LINHAPROCESSOS
                ViewBag.LINHAPROCESSOS = linhasProcesso;
            }
            else
            {
                // se o processo for nulo, e a ViewBag.LINHAPROCESSOS vai nula, que é para não exibir a tabela de linhas de processo na view index
                ViewBag.LINHAPROCESSOS = null;
            }


            // metodo que carrega os processos para a view index, caso contrario nao aparecem os processos na DropDownList processos da view index
            // para manter o cliente selecionado, passo o cliente como parametro
            CarregarProcessosFiltrados();

            return View("Index");
        }

        






        // CRUD gerados automaticamente pelo Visual Studio


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
