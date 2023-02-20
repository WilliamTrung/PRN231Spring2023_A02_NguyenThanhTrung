using ClientRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ClientRepository.Services.Implementation
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        public AuthorService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }
    }
}
