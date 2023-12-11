

using Project.Entities.Base;

namespace Project.Entities.Entities;

public class User : BaseEntity
{
    public string EmailAddress { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

    // Relations

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
    //ctors
    //public User()
    //{
    //    RefreshTokens = new HashSet<RefreshToken>();
    //}
}
