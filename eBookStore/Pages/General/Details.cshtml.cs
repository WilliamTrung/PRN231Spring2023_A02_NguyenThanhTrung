using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.DBContext;
using ClientRepository.Extension;

namespace eBookStore.Pages.General
{
    public class DetailsModel : PageModel
    {
        private HttpClient client;
        private readonly IHttpClientFactory _httpClientFactory;

        public DetailsModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            client = httpClientFactory.CreateClient("BaseClient");
        }

        public User User { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            client.AddTokenHeader(HttpContext.Session.GetString("token"));
            var response = await client.GetAsync("Users?$filter= user_id eq " + ((int)id).ToString());
            if (response != null && response.IsSuccessStatusCode && response.Content != null)
            {
                var users = await response.Content.ReadFromJsonAsync<List<User>>();
                var user = users.FirstOrDefault();
                if (user != null)
                {
                    User = user;
                    return Page();
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
