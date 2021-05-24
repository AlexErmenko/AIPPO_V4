using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain;

namespace WebUI.Pages.WorkshopDetails
{
    public class CreateModel : PageModel
    {
        private readonly Domain.WorkshopContext _context;

        public CreateModel(Domain.WorkshopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DetailId"] = new SelectList(_context.Details, "Id", "MarkDetail");
        ViewData["WorkshopNumber"] = new SelectList(_context.Workshops, "Id", "DirectorName");
            return Page();
        }

        [BindProperty]
        public WorkshopDetail WorkshopDetail { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WorkshopDetails.Add(WorkshopDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
