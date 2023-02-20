using BusinessObject;
using BusinessObject.DBContext;
using DataAccess.Generic;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Implement
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(Context context, IUnitOfWork unitOfWork) : base(context)
        {
            
        }
    }
}
