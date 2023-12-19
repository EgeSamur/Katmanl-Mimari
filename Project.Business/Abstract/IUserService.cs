
using Project.Common.Paging;
using Project.Common.Utilities.Results;
using Project.Entities.Entities;

namespace Project.Business.Abstract;

public interface IUserService
{
    IResult Add(User user);
    IResult Update(User user);
    IResult Delete(User user);
    IDataResult<IPaginate<User>> GetAll();
    IDataResult<User> GetById(Guid id);
    public IDataResult<User> GetByRefreshToken(string refreshToken);
    public IDataResult<User> GetUser(string email);

    //List<OperationClaim> GetClaims(User user);
    IDataResult<User> GetByMail(string mail);
    object GetByMail(Func<object, bool> value);
}
