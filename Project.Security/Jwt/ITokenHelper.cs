
using Project.Entities.Entities;

namespace Project.Security.Jwt;

public interface ITokenHelper
{
    AccessToken CreateToken(User user,IList<Role> roles);
    AccessToken CreateToken(User user);
    RefreshToken CreateRefreshToken(User user);
}