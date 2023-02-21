using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.DBContext;

namespace eBookStore.Pages.Administrator.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.DBContext.Context _context;

        public IndexModel(BusinessObject.DBContext.Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Publishers != null)
            {
                Publisher = await _context.Publishers.ToListAsync();
            }
        }
    }
}
