using Project.DataAccess.Concrete.Base;
using Project.DataAccess.Context;
using Project.Entities.Entities;

namespace Project.DataAccess.Concrete;

public class RefreshTokenRepository : RepositoryBase<RefreshToken, ApplicationDbContext>
{
    public RefreshTokenRepository(ApplicationDbContext context) : base(context)
    {
    }
}
