using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using bruhBruh.Models;

namespace bruhBruh.Views.Veggies
{
    public class CreateModel : PageModel
    {
        private readonly bruhBruh.Models.VeggieContext _context;

        public CreateModel(bruhBruh.Models.VeggieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public veggies veggies { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Veggies == null || veggies == null)
            {
                return Page();
            }

            _context.Veggies.Add(veggies);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
