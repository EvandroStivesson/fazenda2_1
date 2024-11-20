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
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest();

            var cliente = await _context.Clientes
                .Include(c => c.Vendas) // Inclui as vendas do cliente
                .FirstOrDefaultAsync(m => m.ClienteId == id);

            if (cliente == null)
                return NotFound();

            return View(cliente); // Retorna o cliente e suas vendas //TODO lets see about that
        }


        // GET: Clientes/Create
        [HttpGet("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        // POST: Clientes/Edit
        [HttpPost("[action]/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] Cliente clienteAtualizado, int id)
        {
            if (id != clienteAtualizado.ClienteId)
                return BadRequest();
            if (!ModelState.IsValid)
                return View(clienteAtualizado);

            _context.Update(clienteAtualizado);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Clientes/Delete/5
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteId == id);

            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        // POST: Clientes/Delete
        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromForm] Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}