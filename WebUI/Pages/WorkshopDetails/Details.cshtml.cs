using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace WebUI.Pages.WorkshopDetails
{
    public class DetailsModel : PageModel
    {
        private readonly Domain.WorkshopContext _context;

        public DetailsModel(Domain.WorkshopContext context)
        {
            _context = context;
        }

        public WorkshopDetail WorkshopDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkshopDetail = await _context.WorkshopDetails
                .Include(w => w.Detail)
                .Include(w => w.WorkshopNumberNavigation).FirstOrDefaultAsync(m => m.OperationNumber == id);

            if (WorkshopDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
