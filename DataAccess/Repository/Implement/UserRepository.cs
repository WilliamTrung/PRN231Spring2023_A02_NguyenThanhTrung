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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context, IUnitOfWork unitOfWork) : base(context)
        {
        }

        public Task<User?> LoginAsync(string email, string password)
        {
            return GetFirst(expression: c => c.email_address == email && c.password == password, "Role");
        }
    }
}
