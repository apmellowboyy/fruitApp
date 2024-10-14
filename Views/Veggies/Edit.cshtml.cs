using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bruhBruh.Models;

namespace bruhBruh.Views.Veggies
{
    public class EditModel : PageModel
    {
        private readonly bruhBruh.Models.VeggieContext _context;

        public EditModel(bruhBruh.Models.VeggieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public veggies veggies { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Veggies == null)
            {
                return NotFound();
            }

            var veggies =  await _context.Veggies.FirstOrDefaultAsync(m => m.Name == id);
            if (veggies == null)
            {
                return NotFound();
            }
            veggies = veggies;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(veggies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!veggiesExists(veggies.Name))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool veggiesExists(string id)
        {
          return (_context.Veggies?.Any(e => e.Name == id)).GetValueOrDefault();
        }
    }
}
