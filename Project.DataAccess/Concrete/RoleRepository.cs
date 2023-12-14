using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete.Base;
using Project.DataAccess.Context;
using Project.Entities.Entities;

namespace Project.DataAccess.Concrete;

public class RoleRepository : RepositoryBase<Role, ApplicationDbContext>,IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}
