using ClientRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRepository.Services.Implementation
{
    public class PublisherService : BaseService<Author>, IPublisherService
    {
        public PublisherService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }
    }
}
