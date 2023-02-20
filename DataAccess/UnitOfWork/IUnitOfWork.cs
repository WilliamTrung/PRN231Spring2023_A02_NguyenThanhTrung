using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRoleRepository RoleRepository { get; }
        public IUserRepository UserRepository { get; }
        public IPublisherRepository PublisherRepository { get; }
        public IBookRepository BookRepository { get; }
        public IBookAuthorRepository BookAuthorRepository { get; }
        public IAuthorRepository AuthorRepository { get; }
    }
}
