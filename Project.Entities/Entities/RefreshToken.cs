
using Project.Entities.Base;

namespace Project.Entities.Entities;

public class RefreshToken:BaseEntity
{
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public DateTime Created { get; set; }
    
    public bool IsUsed { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}
