
using Project.DTO.Base;

namespace Project.DTO;

public class UserForRegisterDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirtName { get; set; }
    public string LastName { get; set; }
    public string RoleName { get; set; }
}

