using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyVirtualStore.Models;

namespace MyVirtualStore.Controllers
{
    public class TarjetumsController : Controller
    {
        private readonly TiendaVirtualDbContext _context;

        public TarjetumsController(TiendaVirtualDbContext context)
        {
            _context = context;
        }

        // GET: Tarjetums
        public async Task<IActionResult> Index()
        {
              return _context.Tarjeta != null ? 
                          View(await _context.Tarjeta.ToListAsync()) :
                          Problem("Entity set 'TiendaVirtualDbContext.Tarjeta'  is null.");
        }

        // GET: Tarjetums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tarjeta == null)
            {
                return NotFound();
            }

            var tarjetum = await _context.Tarjeta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarjetum == null)
            {
                return NotFound();
            }

            return View(tarjetum);
        }

        // GET: Tarjetums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tarjetums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Numero")] Tarjetum tarjetum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarjetum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarjetum);
        }

        // GET: Tarjetums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tarjeta == null)
            {
                return NotFound();
            }

            var tarjetum = await _context.Tarjeta.FindAsync(id);
            if (tarjetum == null)
            {
                return NotFound();
            }
            return View(tarjetum);
        }

        // POST: Tarjetums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Numero")] Tarjetum tarjetum)
        {
            if (id != tarjetum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarjetum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarjetumExists(tarjetum.Id))
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
            return View(tarjetum);
        }

        // GET: Tarjetums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tarjeta == null)
            {
                return NotFound();
            }

            var tarjetum = await _context.Tarjeta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarjetum == null)
            {
                return NotFound();
            }

            return View(tarjetum);
        }

        // POST: Tarjetums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tarjeta == null)
            {
                return Problem("Entity set 'TiendaVirtualDbContext.Tarjeta'  is null.");
            }
            var tarjetum = await _context.Tarjeta.FindAsync(id);
            if (tarjetum != null)
            {
                _context.Tarjeta.Remove(tarjetum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarjetumExists(int id)
        {
          return (_context.Tarjeta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
