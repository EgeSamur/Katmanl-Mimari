
using Project.Entities.Entities;

namespace Project.Security.Jwt;

public interface ITokenHelper
{
    AccessToken CreateToken(User user,IList<Role> roles);
    RefreshToken CreateRefreshToken(User user);
}