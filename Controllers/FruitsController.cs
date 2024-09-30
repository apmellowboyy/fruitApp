using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bruhBruh.Models;

namespace bruhBruh.Controllers
{
    public class FruitsController : Controller
    {
        private readonly FruitContext _context;

        public FruitsController(FruitContext context)
        {
            _context = context;
        }

        // GET: Fruits
        public async Task<IActionResult> Index()
        {
              return _context.newFruit != null ? 
                          View(await _context.newFruit.ToListAsync()) :
                          Problem("Entity set 'FruitContext.newFruit'  is null.");
        }

        // GET: Fruits/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.newFruit == null)
            {
                return NotFound();
            }

            var fruits = await _context.newFruit
                .FirstOrDefaultAsync(m => m.Name == id);
            if (fruits == null)
            {
                return NotFound();
            }

            return View(fruits);
        }

        // GET: Fruits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fruits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Color,Size,Value")] Fruits fruits)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fruits);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fruits);
        }

        // GET: Fruits/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.newFruit == null)
            {
                return NotFound();
            }

            var fruits = await _context.newFruit.FindAsync(id);
            if (fruits == null)
            {
                return NotFound();
            }
            return View(fruits);
        }

        // POST: Fruits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Color,Size,Value")] Fruits fruits)
        {
            if (id != fruits.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fruits);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FruitsExists(fruits.Name))
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
            return View(fruits);
        }

        // GET: Fruits/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.newFruit == null)
            {
                return NotFound();
            }

            var fruits = await _context.newFruit
                .FirstOrDefaultAsync(m => m.Name == id);
            if (fruits == null)
            {
                return NotFound();
            }

            return View(fruits);
        }

        // POST: Fruits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.newFruit == null)
            {
                return Problem("Entity set 'FruitContext.newFruit'  is null.");
            }
            var fruits = await _context.newFruit.FindAsync(id);
            if (fruits != null)
            {
                _context.newFruit.Remove(fruits);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FruitsExists(string id)
        {
          return (_context.newFruit?.Any(e => e.Name == id)).GetValueOrDefault();
        }
    }
}
