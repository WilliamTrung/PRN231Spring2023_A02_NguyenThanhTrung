using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.DBContext;

namespace eBookStore.Pages.Administrator.Users
{
    public class DeleteModel : PageModel
    {
        private HttpClient client;
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            client = httpClientFactory.CreateClient("BaseClient");
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            client.AddTokenHeader(HttpContext.Session.GetString("token"));
            var response = await client.GetAsync("Users?$filter= User_id eq " + ((int)id).ToString());
            if (response != null && response.IsSuccessStatusCode && response.Content != null)
            {
                var users = await response.Content.ReadFromJsonAsync<List<User>>();
                var user = Users.FirstOrDefault();
                if (user != null)
                {
                    user = user;
                    return Page();
                }
            }
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            client.AddTokenHeader(HttpContext.Session.GetString("token"));
            var response = await client.DeleteAsync("Users/" + User.User_id.ToString());
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
