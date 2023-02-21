using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using BusinessObject.DBContext;
using ClientRepository.Extension;

namespace eBookStore.Pages.Administrator.Publishers
{
    public class CreateModel : PageModel
    {
        private HttpClient client;
        private readonly IHttpClientFactory _httpClientFactory;

        public CreateModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            client = httpClientFactory.CreateClient("BaseClient");
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Publisher Publisher { get; set; } = null!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            client.AddTokenHeader(HttpContext.Session.GetString("token"));
            var response = await client.PostAsJsonAsync("Publishers", Publisher);
            if (response.IsSuccessStatusCode)
                return RedirectToPage("./Index");
            return Page();
        }
    }
}
