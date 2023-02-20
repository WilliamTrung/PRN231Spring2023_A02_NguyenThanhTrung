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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }
    }
}
