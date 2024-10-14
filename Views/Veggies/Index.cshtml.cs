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
    public class IndexModel : PageModel
    {
        private readonly bruhBruh.Models.VeggieContext _context;

        public IndexModel(bruhBruh.Models.VeggieContext context)
        {
            _context = context;
        }

        public IList<veggies> veggies { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Veggies != null)
            {
                veggies = await _context.Veggies.ToListAsync();
            }
        }
    }
}
