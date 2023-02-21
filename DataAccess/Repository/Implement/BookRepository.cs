using BusinessObject;
using BusinessObject.DBContext;
using DataAccess.Generic;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Implement
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly IUnitOfWork _unitOfWork;   
        public BookRepository(Context context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task<IEnumerable<Book>> Get(Expression<Func<Book, bool>>? expression = null, params string[] includeProperties)
        {
            var list = await base.Get(expression, includeProperties);
            foreach (var item in list)
            {
                var bookAuthors = await _unitOfWork.BookAuthorRepository.Get(expression: ba => ba.book_id == item.book_id, includeProperties: "Author");
                item.BookAuthor = bookAuthors.ToList();
            }
            return list;
        }
    }
}
