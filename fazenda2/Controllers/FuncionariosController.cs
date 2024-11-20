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
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FuncionariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionario.ToListAsync());
        }

        // GET: Funcionarios/Details/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.id_funcionario == id);
            if (funcionario == null)
                return NotFound();

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        [HttpGet("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Funcionario funcionario)
        {
            if (!ModelState.IsValid)
                return View(funcionario);

            _context.Add(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionarios/Edit/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
                return NotFound();

            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        [HttpPost("[action]/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] Funcionario funcionario, int id)
        {
            if (id != funcionario.id_funcionario)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(funcionario);

            _context.Update(funcionario);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Funcionarios/Delete/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.id_funcionario == id);
            if (funcionario == null)
                return NotFound();

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromForm] Funcionario funcionario)
        {
            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}