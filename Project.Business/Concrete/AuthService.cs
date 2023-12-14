using Project.Business.Abstract;
using Project.Common.Utilities.Results;
using Project.DataAccess.Abstract;
using Project.DTO;
using Project.Entities.Entities;
using Project.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Concrete;

public class AuthService :IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IRefreshTokenService _refreshTokenService;

    public AuthService(IUserService userService, ITokenHelper tokenHelper, IRefreshTokenService refreshTokenService)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _refreshTokenService = refreshTokenService;
    }

    public IDataResult<User> Register(UserForRegisterDto userForRegisterDto,string password)
    {

        UserExist(userForRegisterDto.Email);
        byte[] passwordHash,passwordSalt;

        // out iki tane return yapmadan yukarıda tanımladığım dalgalrı değiştirir.
        HashingHelper.CreatePasswordHash(password,out passwordHash, out passwordSalt);

        var user = new User
        {
            EmailAddress = userForRegisterDto.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            
          
        };

        _userService.Add(user);
        return new SuccessDataResult<User>(user, "User Registered.");
    }

    public IDataResult<LoginReturnDto> Login(UserForLoginDto userForLoginDto)
    {
        
        var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
        if (userToCheck == null)
        {
            return new ErrorDataResult<LoginReturnDto>("User Not Found.");
        }
        if (HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
        {
           
            var accesTokenData = GetAccessTokenWithoutRole(userToCheck);
            var refreshTokenData = GetRefreshToken(userToCheck);
            var accesToken = accesTokenData.Data;
            var refreshToken = refreshTokenData.Data; // Db'ye eklemeliyiz.
            var rf = new RefreshToken
            {
                Token = refreshToken.Token,
                Expires = refreshToken.Expires,
                Created = refreshToken.Created,
                IsUsed = refreshToken.IsUsed,
                UserId = userToCheck.Id,
                User = userToCheck,
            };
            _refreshTokenService.Add(rf);

            var loginDataDto = new LoginReturnDto
            {
                Token = accesToken,
                RefreshToken = refreshToken,
            };
            return new SuccessDataResult<LoginReturnDto>(loginDataDto, "Token Created.");
            
        }
        else
        {
            return new ErrorDataResult<LoginReturnDto>("Wrong Password.");
        }

       
    }

    public void UserExist(string email)
    {
        var result = _userService.GetByMail(email).Data;
        if (result != null)
            throw new Exception("User email already exists.");
    }

    public IDataResult<AccessToken> GetAccessToken(User user ,IList<Role> roles)
    {
        var accessToken = _tokenHelper.CreateToken(user,roles);
        return new SuccessDataResult<AccessToken>(accessToken, "Token Created.");
    }
    public IDataResult<AccessToken> GetAccessTokenWithoutRole(User user)
    {
        var accessToken = _tokenHelper.CreateToken(user);
        return new SuccessDataResult<AccessToken>(accessToken, "Token Created.");
    }

    public IDataResult<RefreshToken> GetRefreshToken(User user)
    {
        var refreshToken = _tokenHelper.CreateRefreshToken(user);
        return new SuccessDataResult<RefreshToken>(refreshToken, "Token Created.");
    }
}
