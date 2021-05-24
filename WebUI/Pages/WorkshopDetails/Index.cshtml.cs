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
    public class IndexModel : PageModel
    {
        private readonly Domain.WorkshopContext _context;

        public IndexModel(Domain.WorkshopContext context)
        {
            _context = context;
        }

        public IList<WorkshopDetail> WorkshopDetail { get;set; }

        public async Task OnGetAsync()
        {
            var workshops  = await _context.Workshops.ToListAsync();

            var details = await _context.Details.ToListAsync();

            ViewData["Workshop"] = workshops.Any();
            ViewData["Details"] = details.Any();


            WorkshopDetail = await _context.WorkshopDetails
                .Include(w => w.Detail)
                .Include(w => w.WorkshopNumberNavigation).ToListAsync();
        }
    }
}
