
using Project.Common.Utilities.Results;
using Project.DataAccess.Abstract.Base;
using Project.Entities.Entities;

namespace Project.DataAccess.Abstract;

public interface IUserRepository: IRepository<User>
{
    public IDataResult<User> GetUserByRToken(string refreshToken);
}
