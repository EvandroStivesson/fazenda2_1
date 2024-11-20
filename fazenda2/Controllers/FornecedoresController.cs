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
    public class FornecedoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FornecedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fornecedores
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fornecedor.ToListAsync());
        }

        // GET: Fornecedores/Details/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var fornecedor = await _context.Fornecedor
                .FirstOrDefaultAsync(m => m.FornecedorId == id);

            if (fornecedor == null)
                return NotFound();

            return View(fornecedor);
        }

        // GET: Fornecedores/Create
        [HttpGet("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedores/Create
        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
                return View(fornecedor);

            _context.Add(fornecedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Fornecedores/Edit/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var fornecedor = await _context.Fornecedor.FindAsync(id);
            if (fornecedor == null)
                return NotFound();

            return View(fornecedor);
        }

        // POST: Fornecedores/Edit/5
        [HttpPost("[action]/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] Fornecedor fornecedor, int id)
        {
            if (id != fornecedor.FornecedorId)
                return BadRequest();
            if (!ModelState.IsValid)
                return View(fornecedor);

            _context.Update(fornecedor);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Fornecedores/Delete/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var fornecedor = await _context.Fornecedor
                .FirstOrDefaultAsync(m => m.FornecedorId == id);

            if (fornecedor == null)
                return NotFound();

            return View(fornecedor);
        }

        // POST: Fornecedores/Delete
        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromForm] Fornecedor fornecedor)
        {
            _context.Fornecedor.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}