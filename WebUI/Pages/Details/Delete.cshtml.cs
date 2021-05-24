using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace WebUI
{
    public class DeleteModel : PageModel
    {
        private readonly Domain.WorkshopContext _context;

        public DeleteModel(Domain.WorkshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Detail Detail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Detail = await _context.Details.FirstOrDefaultAsync(m => m.Id == id);

            if (Detail == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Detail = await _context.Details.FindAsync(id);

            if (Detail != null)
            {
                _context.Details.Remove(Detail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
