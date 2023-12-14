

using Project.Common.Utilities.Results;
using Project.Entities.Entities;
using Project.Security.Jwt;

namespace Project.Business.Abstract;

public interface IRefreshTokenService
{
    IResult Add(RefreshToken user);
    IDataResult<AccessToken> RefreshToken(string refreshToken);
}
