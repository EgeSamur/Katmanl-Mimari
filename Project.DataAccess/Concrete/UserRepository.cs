using Project.DataAccess.Concrete.Base;
using Project.DataAccess.Context;
using Project.Entities.Entities;

namespace Project.DataAccess.Concrete;

public class UserRepository : RepositoryBase<User, ApplicationDbContext>
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}
