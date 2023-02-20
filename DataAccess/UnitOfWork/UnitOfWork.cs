using BusinessObject.Context;
using Repository.Repository;
using Repository.Repository.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthorRepository AuthorRepository { get; } = null!;

        public IRoleRepository RoleRepository { get; } = null!;

        public IUserRepository UserRepository { get; } = null!;

        public IPublisherRepository PublisherRepository { get; } = null!;

        public IBookRepository BookRepository { get; } = null!;

        public IBookAuthorRepository BookAuthorRepository { get; } = null!;

        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
            Init();
        }
        private void Init()
        {
            IAuthorRepository AuthorRepository = new AuthorRepository(_context);

            IRoleRepository RoleRepository = new RoleRepository(_context);

            IUserRepository UserRepository = new UserRepository(_context);

            IPublisherRepository PublisherRepository = new PublisherRepository(_context);

            IBookRepository BookRepository = new BookRepository(_context);

            IBookAuthorRepository BookAuthorRepository = new BookAuthorRepository(_context);
        }
    }
}
