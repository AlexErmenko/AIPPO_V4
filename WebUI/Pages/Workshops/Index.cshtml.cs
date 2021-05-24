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
    public class IndexModel : PageModel
    {
        private readonly Domain.WorkshopContext _context;

        public IndexModel(Domain.WorkshopContext context)
        {
            _context = context;
        }

        public IList<Workshop> Workshop { get;set; }

        public async Task OnGetAsync()
        {
            Workshop = await _context.Workshops.ToListAsync();
        }
    }
}
