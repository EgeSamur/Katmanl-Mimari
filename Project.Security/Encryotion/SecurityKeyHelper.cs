using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Project.Security.Encryotion;

public partial class SecurityKeyHelper
{
    public static SecurityKey CreateSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}
