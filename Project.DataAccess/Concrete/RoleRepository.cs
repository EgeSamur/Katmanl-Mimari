using Project.DataAccess.Concrete.Base;
using Project.DataAccess.Context;
using Project.Entities.Entities;

namespace Project.DataAccess.Concrete;

public class RoleRepository : RepositoryBase<Role, ApplicationDbContext>
{
    public RoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}
