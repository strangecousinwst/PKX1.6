using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PKX.Data;
using PKX.Models;

namespace PKX.Controllers
{
    public class GCliSenhas2 : Controller
    {
        private readonly ApplicationDbContext dbp;

        public GCliSenhas2(ApplicationDbContext context)
        {
            dbp = context;
        }
        public IActionResult Index(int id)
        {
            PreencherViewBagCliente(PreencherListaClientes());
            ListarItens(id);
            
            return View();
        }
        public IActionResult Eliminar(int idItem)
        {
            EliminarLinhaItem(idItem);
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int idItem)
        {
            if (idItem > 0)
            {
                ViewBag.ITEM = dbp.Itens.Where(x => x.ClienteId == idItem).FirstOrDefault();
                return View();
            }

            return RedirectToAction("Index");
        }
        
        // método para preencher lista de clientes
        private List<Cliente> PreencherListaClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            listaClientes = dbp.Clientes.ToList();
            return listaClientes;
        }
        // método para encher viewbag com a lista de clientes
        private void PreencherViewBagCliente(List<Cliente> listaClientes)
        {
            listaClientes = PreencherListaClientes();
            ViewBag.CLIENTES = new SelectList(listaClientes, "Id", "NomeCliente");
        }
        //método para preencher viewbag com o cliente selecionado e com os items do cliente
        private void ListarItens(int id)
        {
            if (id != -1)
            {
                ViewBag.CLISELECIONADO = id;
                ViewBag.LISTADO = dbp.Itens.Where(x => x.ClienteId == id).Include(y => y.TipoVirtual).ToList();
            }
            
        }
        //método para sacar id do Cliente

        //método para eliminar linha de item
        private void EliminarLinhaItem(int idItem)
        {
            Item i = new Item();
            i = dbp.Itens.Where(x => x.Id == idItem).FirstOrDefault();
            dbp.Itens.Remove(i);
            dbp.SaveChanges();
            
        }
        // método para editar linha de item
        //private void EditarLinhaItem(int idItem)
        //{

        //}
    }

}
