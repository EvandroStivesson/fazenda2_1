using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fazenda2.Data;
using fazenda2.Models;

namespace fazenda2.Controllers
{
    [Route("[controller]")]
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        // GET: Produtos/Details/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.ProdutoId == id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // GET: Produtos/Create
        [HttpGet("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Produto produto)
        {
            if (!ModelState.IsValid)
                return View(produto);

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Produtos/Edit/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost("[action]/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] Produto produto, int id)
        {
            if (id != produto.ProdutoId)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(produto);

            _context.Update(produto);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Produtos/Delete/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromForm] Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}