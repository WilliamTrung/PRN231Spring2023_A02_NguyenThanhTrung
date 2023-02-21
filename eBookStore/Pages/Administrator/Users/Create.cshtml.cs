using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using BusinessObject.DBContext;

namespace eBookStore.Pages.Administrator.Users
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObject.DBContext.Context _context;

        public CreateModel(BusinessObject.DBContext.Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["pub_id"] = new SelectList(_context.Publishers, "pub_id", "city");
        ViewData["role_id"] = new SelectList(_context.Roles, "role_id", "role_id");
            return Page();
        }

        [BindProperty]
        public User User { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
