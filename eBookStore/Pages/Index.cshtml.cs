using ClientRepository.Extension;
using ClientRepository.Models;
using eBookStore.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;

namespace eBookStore.Pages
{
    public class IndexModel : PageModel
    {
        private HttpClient client;
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        [BindProperty]
        public string Email { get; set; } = null!;
        [BindProperty]
        public string Password { get; set; } = null!;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            client = _httpClientFactory.CreateClient("BaseClient");
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostLoginAsync()
        {
            //Request.Headers.Authorization = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFkbWluQGVzdG9yZS5jb20iLCJyb2xlIjoiQWRtaW5pc3RyYXRvciIsIm5iZiI6MTY3NDU1MjYzOSwiZXhwIjoxNjc0NTUyNjk5LCJpYXQiOjE2NzQ1NTI2MzksImlzcyI6Imlzc3VlciIsImF1ZCI6ImF1ZGllbmNlIn0.mnZAj8Zkeut8hPtmkGfJZB5NjrG2pTdw2T1JtemjBKM";            
            var param = new Dictionary<string, string>{
                { "email" , Email },
                { "password" , Password }
            };
            HttpContext.Session.Clear();
            //var request = new HttpRequestMessage(HttpMethod.Post, requestUri: "login");
            //request.Content = encodedContent;
            var response = await client.PostAsync("login" + HttpRequestSupport.GetQueryPath(param), content: null);
            if (response.IsSuccessStatusCode)
            {
                string? token = await response.Content.ReadFromJsonAsync<string>();
                HttpContext.Session.SetString("token", token);
                var login = new Dictionary<string, string>
                {
                    {"token", token }
                };
                var response_getlogin = await client.GetAsync("login" + HttpRequestSupport.GetQueryPath(login));
                User member = (User)await response_getlogin.Content.ReadFromJsonAsync(typeof(User));
                HttpContext.Session.SetLoginUser(member);
                if (member.email_address.Contains("admin"))
                {
                    HttpContext.Session.SetString("role", "Administrator");
                    return RedirectToPage("/Administrator/Users/Index");
                }
                return RedirectToPage("User/Profile");
            }
            return Page();
        }
    }
}