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
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(Context context, IUnitOfWork unitOfWork) : base(context)
        {
        }
    }
}
