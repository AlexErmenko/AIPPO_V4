﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain;

namespace WebUI.Pages.Workshops
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
            return Page();
        }

        [BindProperty]
        public Workshop Workshop { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Workshops.Add(Workshop);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
