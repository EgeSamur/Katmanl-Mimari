using Project.Business.Abstract;
using Project.Common.Utilities.Results;
using Project.DataAccess.Abstract;
using Project.Entities.Entities;
using Project.Security.Jwt;


namespace Project.Business.Concrete;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    public RefreshTokenService(IUserService userService, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public IResult Add(RefreshToken rft)
    {
        _refreshTokenRepository.Add(rft);
        return new SuccessResult("Refresh Token Added.");
    }

    public IDataResult<AccessToken> RefreshToken(string refreshToken)
    {
        var userData = _userService.GetByRefreshToken(refreshToken);
        if (userData != null) 
        {
            //var user = _userService.GetByRefreshToken(refreshToken);
            var user = userData.Data;
            var userRefreshToken = user.RefreshTokens.FirstOrDefault(rt => rt.Token == refreshToken);
            var refrestokenexp = userRefreshToken.Expires;
            //userRefreshToken.IsUsed = true; --> Çalışmıyor.
            var now = DateTime.UtcNow;
            if (now > refrestokenexp)
            {
                return new ErrorDataResult<AccessToken>("Refresh Token's Exp Time İs Over.");
            }
            else
            {
                var newToken = _tokenHelper.CreateToken(user);
                return new SuccessDataResult<AccessToken>(newToken,"New token created.");

            }
        }
        return new ErrorDataResult<AccessToken>("Refresh Token's Exp Time İs Over.");

    }
}
