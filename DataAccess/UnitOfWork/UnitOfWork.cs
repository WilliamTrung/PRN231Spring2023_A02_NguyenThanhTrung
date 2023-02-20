using BusinessObject.DBContext;
using DataAccess.Repository;
using DataAccess.Repository.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthorRepository AuthorRepository { get; private set; } = null!;

        public IRoleRepository RoleRepository { get; private set; } = null!;

        public IUserRepository UserRepository { get; private set; } = null!;

        public IPublisherRepository PublisherRepository { get; private set; } = null!;

        public IBookRepository BookRepository { get; private set; } = null!;

        public IBookAuthorRepository BookAuthorRepository { get; private set; } = null!;

        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
            Init();
        }
        private void Init()
        {
            AuthorRepository = new AuthorRepository(_context, this);            

            RoleRepository = new RoleRepository(_context, this);

            UserRepository = new UserRepository(_context, this);

            PublisherRepository = new PublisherRepository(_context, this);

            BookRepository = new BookRepository(_context, this);

            BookAuthorRepository = new BookAuthorRepository(_context, this);
        }
    }
}
