using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace WebUI.Pages.WorkshopDetails
{
    public class EditModel : PageModel
    {
        private readonly Domain.WorkshopContext _context;

        public EditModel(Domain.WorkshopContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["DetailId"] = new SelectList(_context.Details, "Id", "MarkDetail");
           ViewData["WorkshopNumber"] = new SelectList(_context.Workshops, "Id", "DirectorName");
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

            _context.Attach(WorkshopDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkshopDetailExists(WorkshopDetail.OperationNumber))
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

        private bool WorkshopDetailExists(int id)
        {
            return _context.WorkshopDetails.Any(e => e.OperationNumber == id);
        }
    }
}
