using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fazenda2.Data;
using fazenda2.Models;

namespace fazenda2.Controllers
{
    [Route("[controller]")]
    public class VendasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vendas
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vendas.Include(v => v.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vendas/Details/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var venda = await _context.Vendas
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (venda == null)
                return NotFound();

            return View(venda);
        }

        // GET: Vendas/Create
        [HttpGet("[action]")]
        public IActionResult Create()
        {
            ViewBag.Clientes =
                new SelectList(_context.Clientes, "ClienteId", "Nome"); // Preenchendo a lista de clientes
            ViewBag.Produtos = _context.Produtos.ToList(); // Preenchendo a lista de produtos

            return View();
        }

        // POST: Vendas/Create
        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Venda venda, List<int> ProdutoIds, List<int> Quantidades)
        {
            var produtos = new List<Produto>();

            for (var i = 0; i < ProdutoIds.Count(); i++)
            {
                var produto = await _context.Produtos.FirstAsync(p => p.ProdutoId == ProdutoIds[i]);
                produtos.Add(produto);
                venda.Total += Quantidades[i] * produto.Preco;
            }

            _context.Add(venda);
            await _context.SaveChangesAsync();

            // Adiciona as entradas de ProdutoVenda
            for (var i = 0; i < produtos.Count; i++)
            {
                _context.ProdutosVendas.Add(new ProdutoVenda()
                {
                    VendaId = venda.VendaId,
                    ProdutoId = produtos[i].ProdutoId,
                    Quantidade = Quantidades[i]
                });

                var produto = produtos[i];
                produto.Quantidade -= Quantidades[i];
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Vendas/Edit/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
                return NotFound();

            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", venda.ClienteId);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        [HttpPost("[action]/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] Venda venda, int id)
        {
            if (id != venda.VendaId)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", venda.ClienteId);
                return View(venda);
            }

            _context.Update(venda);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Vendas/Delete/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var venda = await _context.Vendas
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (venda == null)
                return NotFound();

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromForm] Venda venda)
        {
            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}