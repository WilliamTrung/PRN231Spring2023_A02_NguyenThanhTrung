using ClientRepository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRepository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IAuthorService AuthorService { get; }
        public IBookAuthorService BookAuthorService { get; }
        public IBookService BookService { get; }
        public IPublisherService PublisherService { get; }
        public IUserService UserService { get; }
        public IRoleService RoleService { get; }
    }
}
