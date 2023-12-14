
using Project.DTO.Base;

namespace Project.DTO;

public class UserForLoginDto :IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

