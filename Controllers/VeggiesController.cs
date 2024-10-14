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
    public class VeggiesController : Controller
    {
        private readonly VeggieContext _context;

        public VeggiesController(VeggieContext context)
        {
            _context = context;
        }

        // GET: Veggies
        public async Task<IActionResult> Index()
        {
            return _context.Veggies != null ?
                        View(await _context.Veggies.ToListAsync()) :
                        Problem("Entity set 'VeggieContext.Veggies' is null.");
        }

        // GET: Veggies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Veggies == null)
            {
                return NotFound();
            }

            var veggies = await _context.Veggies
                .FirstOrDefaultAsync(m => m.Name == id);
            if (veggies == null)
            {
                return NotFound();
            }

            return View(veggies);
        }

        // GET: Veggies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veggies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Color,Size,Value")] veggies veggies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veggies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veggies);
        }

        // GET: Veggies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Veggies == null)
            {
                return NotFound();
            }

            var veggies = await _context.Veggies.FindAsync(id);
            if (veggies == null)
            {
                return NotFound();
            }
            return View(veggies);
        }

        // POST: Veggies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Color,Size,Value")] veggies veggies)
        {
            if (id != veggies.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veggies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeggiesExists(veggies.Name))
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
            return View(veggies);
        }

        // GET: Veggies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Veggies == null)
            {
                return NotFound();
            }

            var veggies = await _context.Veggies
                .FirstOrDefaultAsync(m => m.Name == id);
            if (veggies == null)
            {
                return NotFound();
            }

            return View(veggies);
        }

        // POST: Veggies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Veggies == null)
            {
                return Problem("Entity set 'VeggieContext.Veggies' is null.");
            }
            var veggies = await _context.Veggies.FindAsync(id);
            if (veggies != null)
            {
                _context.Veggies.Remove(veggies);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeggiesExists(string id)
        {
            return (_context.Veggies?.Any(e => e.Name == id)).GetValueOrDefault();
        }
    }
}
