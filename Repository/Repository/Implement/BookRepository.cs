using BusinessObject;
using BusinessObject.Context;
using Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Implement
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(Context context) : base(context)
        {
        }
    }
}
