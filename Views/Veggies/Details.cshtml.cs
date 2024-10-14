using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using bruhBruh.Models;

namespace bruhBruh.Views.Veggies
{
    public class DetailsModel : PageModel
    {
        private readonly bruhBruh.Models.VeggieContext _context;

        public DetailsModel(bruhBruh.Models.VeggieContext context)
        {
            _context = context;
        }

      public veggies veggies { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Veggies == null)
            {
                return NotFound();
            }

            var veggies = await _context.Veggies.FirstOrDefaultAsync(m => m.Name == id);
            if (veggies == null)
            {
                return NotFound();
            }
            else 
            {
                veggies = veggies;
            }
            return Page();
        }
    }
}
