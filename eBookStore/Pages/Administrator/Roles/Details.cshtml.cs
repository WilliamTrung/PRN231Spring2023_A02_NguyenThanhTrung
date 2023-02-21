using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.DBContext;

namespace eBookStore.Pages.Administrator.Roles
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessObject.DBContext.Context _context;

        public DetailsModel(BusinessObject.DBContext.Context context)
        {
            _context = context;
        }

      public Role Role { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FirstOrDefaultAsync(m => m.Role_id == id);
            if (role == null)
            {
                return NotFound();
            }
            else 
            {
                role = role;
            }
            return Page();
        }
    }
}
