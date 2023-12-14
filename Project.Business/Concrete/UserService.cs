using Project.Business.Abstract;
using Project.Common.Paging;
using Project.Common.Utilities.Results;
using Project.DataAccess.Abstract;
using Project.Entities.Entities;

namespace Project.Business.Concrete;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IResult Add(User user)
    {
        _userRepository.Add(user);
        return new SuccessResult("User Added.");
    }
    public IResult Update(User user)
    {
        _userRepository.Update(user);
        return new SuccessResult("User Updated.");
    }
    public IResult Delete(User user)
    {
        _userRepository.Delete(user);
        return new SuccessResult("User Deleted.");
    }
    public IDataResult<IPaginate<User>> GetAll() 
    {
        var result = _userRepository.GetList();
        return new SuccessDataResult<IPaginate<User>>(result); 
        
    }

    public IDataResult<User> GetById(Guid id)
    {
        var result = _userRepository.Get(I => I.Id == id);
        return new SuccessDataResult<User>(result);

    }

    public IDataResult<User> GetByRefreshToken(string refreshToken)
    {
        var result = _userRepository.GetUserByRToken(refreshToken);
        var user = result.Data;
        return new SuccessDataResult<User>(user);

    }

    //public List<OperationClaim> GetClaims(User user)
    //{
    //    throw new NotImplementedException();
    //}

    public IDataResult<User> GetByMail(string mail)
    {
       var result = _userRepository.Get(U => U.EmailAddress == mail);
        return new SuccessDataResult<User>(result);
    }

    public object GetByMail(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}
