using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace WebUI.Pages.Workshops
{
    public class DetailsModel : PageModel
    {
        private readonly Domain.WorkshopContext _context;

        public DetailsModel(Domain.WorkshopContext context)
        {
            _context = context;
        }

        public Workshop Workshop { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Workshop = await _context.Workshops.FirstOrDefaultAsync(m => m.Id == id);

            if (Workshop == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
