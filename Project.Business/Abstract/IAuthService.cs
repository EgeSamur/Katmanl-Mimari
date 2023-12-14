using Azure.Core;
using Project.Common.Utilities.Results;
using Project.DTO;
using Project.Entities.Entities;
using Project.Security.Jwt;

namespace Project.Business.Abstract;

public interface IAuthService
{
    IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
    IDataResult<LoginReturnDto> Login(UserForLoginDto userForLoginDto);
    public IDataResult<RefreshToken> GetRefreshToken(User user);
    void UserExist(string email);
    IDataResult<Security.Jwt.AccessToken> GetAccessToken(User user, IList<Role> roles);
    IDataResult<Security.Jwt.AccessToken> GetAccessTokenWithoutRole(User user);


}