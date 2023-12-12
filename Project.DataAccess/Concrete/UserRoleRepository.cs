using Project.DataAccess.Concrete.Base;
using Project.DataAccess.Context;
using Project.Entities.Entities;

namespace Project.DataAccess.Concrete;

public class UserRoleRepository : RepositoryBase<UserRole, ApplicationDbContext>
{
    public UserRoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}