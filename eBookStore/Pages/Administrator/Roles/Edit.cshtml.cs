using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.DBContext;

namespace eBookStore.Pages.Administrator.Roles
{
    public class EditModel : PageModel
    {
        private readonly BusinessObject.DBContext.Context _context;

        public EditModel(BusinessObject.DBContext.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Role Role { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role =  await _context.Roles.FirstOrDefaultAsync(m => m.Role_id == id);
            if (role == null)
            {
                return NotFound();
            }
            role = role;
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

            _context.Attach(Role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(Role.Role_id))
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

        private bool RoleExists(int id)
        {
          return _context.Roles.Any(e => e.Role_id == id);
        }
    }
}
