using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaRestaurante.Data;
using SistemaRestaurante.Models;

namespace SistemaRestaurante.Controllers
{
    public class ItemPedidoController : Controller
    {
        private readonly RestauranteContext _context;

        public ItemPedidoController(RestauranteContext context)
        {
            _context = context;
        }

        // GET: ItemPedido
        public async Task<IActionResult> Index()
        {
            var restauranteContext = _context.ItensPedido.Include(i => i.Pedido);
            return View(await restauranteContext.ToListAsync());
        }

        // GET: ItemPedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItensPedido == null)
            {
                return NotFound();
            }

            var itemPedido = await _context.ItensPedido
                .Include(i => i.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            return View(itemPedido);
        }

        // GET: ItemPedido/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id");
            return View();
        }

        // POST: ItemPedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Prato,Bebida,Quantidade,PedidoId")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", itemPedido.PedidoId);
            return View(itemPedido);
        }

        // GET: ItemPedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItensPedido == null)
            {
                return NotFound();
            }

            var itemPedido = await _context.ItensPedido.FindAsync(id);
            if (itemPedido == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", itemPedido.PedidoId);
            return View(itemPedido);
        }

        // POST: ItemPedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Prato,Bebida,Quantidade,PedidoId")] ItemPedido itemPedido)
        {
            if (id != itemPedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemPedidoExists(itemPedido.Id))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", itemPedido.PedidoId);
            return View(itemPedido);
        }

        // GET: ItemPedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItensPedido == null)
            {
                return NotFound();
            }

            var itemPedido = await _context.ItensPedido
                .Include(i => i.Pedido)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            return View(itemPedido);
        }

        // POST: ItemPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItensPedido == null)
            {
                return Problem("Entity set 'RestauranteContext.ItensPedido'  is null.");
            }
            var itemPedido = await _context.ItensPedido.FindAsync(id);
            if (itemPedido != null)
            {
                _context.ItensPedido.Remove(itemPedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemPedidoExists(int id)
        {
          return (_context.ItensPedido?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
