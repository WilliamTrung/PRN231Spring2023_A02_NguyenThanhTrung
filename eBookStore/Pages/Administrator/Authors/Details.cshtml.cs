using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.DBContext;
using ClientRepository.Extension;
using System.Diagnostics.Metrics;
using Newtonsoft.Json.Linq;
using ClientRepository.Models;

namespace eBookStore.Pages.Administrator.Authors
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

        public Author Author { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            client.AddTokenHeader(HttpContext.Session.GetString("token"));
            var response = await client.GetAsync("Authors?$filter= author_id eq " + ((int)id).ToString());
            if (response != null && response.IsSuccessStatusCode && response.Content != null)
            {
                var authors = await response.Content.ReadFromJsonAsync<List<Author>>();
                var author = authors.FirstOrDefault();
                if (author != null)
                {
                    Author = author;
                    return Page();
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
