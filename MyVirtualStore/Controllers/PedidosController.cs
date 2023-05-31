using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVirtualStore.Models;

namespace MyVirtualStore.Controllers
{
    public class PedidosController : Controller
    {
        private readonly TiendaVirtualDbContext _dbContext;

        public PedidosController(TiendaVirtualDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IActionResult> Index()
        {
            var cliente = await _dbContext.Pedidos.Include(c=>c.IdClienteNavigation).Include(t=>t.IdTarjetaNavigation).ToListAsync();
            if(cliente == null)
            {
                return NotFound();
            }            

            return View(cliente);
        }

        public async Task<IActionResult> buscar(int id)
        {
            var pedido = await _dbContext.Pedidos.FindAsync(id);
            if(id<=0 && pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }
    }
}
