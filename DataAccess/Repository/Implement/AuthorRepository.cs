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
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorRepository(Context context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork= unitOfWork;
        }
        public override async Task<IEnumerable<Author>> Get(Expression<Func<Author, bool>>? expression = null, params string[] includeProperties)
        {
            var list = await base.Get(expression, includeProperties);
            foreach (var item in list)
            {
                var find = await _unitOfWork.BookAuthorRepository.Get(expression: e => e.author_id == item.author_id, "Book");
                item.BookAuthors = find.ToList();
            }
            return list;
        }
    }
}
