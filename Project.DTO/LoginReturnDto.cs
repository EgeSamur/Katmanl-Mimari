using Project.Entities.Entities;
using Project.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO
{
    public class LoginReturnDto
    {
        public AccessToken Token { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
