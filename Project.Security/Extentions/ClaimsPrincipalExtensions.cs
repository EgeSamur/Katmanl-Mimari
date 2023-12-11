
using System.Security.Claims;

namespace Project.Security.Extentions;

public static class ClaimsPrincipalExtensions
{
    public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        List<string>? result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
        return result;
    }

    public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.Claims(ClaimTypes.Role);
    }

    public static Guid? GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal?.Claims == null) return null;

        var claim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (claim == null) return null;

        if (Guid.TryParse(claim.Value, out Guid userId))
        {
            return userId;
        }

        return null;
    }
}
