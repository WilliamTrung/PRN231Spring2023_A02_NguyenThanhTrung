using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClientRepository.Extension;
using ClientRepository.Models;

namespace eBookStore.Pages.Administrator.Authors
{
    public class IndexModel : PageModel
    {
        private HttpClient client;
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            client = _httpClientFactory.CreateClient("BaseClient");
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                client.AddTokenHeader(HttpContext.Session.GetString("token"));
                var response = await client.GetAsync(requestUri: "Authors");
                if (response.IsSuccessStatusCode)
                {
                    var authors = await response.Content.ReadFromJsonAsync<List<Author>>();
                    //if (content != null)
                    //{
                    //var products = JsonSerializer.Deserialize<List<Product>>(content, jsonOption);
                    if (authors != null)
                    {
                        Author = authors;
                    }
                    //}
                }
                else
                {
                    ViewData["Error"] = response.StatusCode;
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
