using ClientRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRepository.Services.Implementation
{
    public class BookAuthorService : BaseService<BookAuthor>, IBookAuthorService
    {
        public BookAuthorService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }
    }
}
