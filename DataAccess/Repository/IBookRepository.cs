using BusinessObject;
using DataAccess.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
    }
}
