using ClientRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRepository.Services.Implementation
{
    public class BookService : BaseService<Book>, IBookService
    {
        public BookService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }
    }
}
