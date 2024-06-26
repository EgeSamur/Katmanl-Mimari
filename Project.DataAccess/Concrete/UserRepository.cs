﻿using Project.Common.Utilities.Results;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete.Base;
using Project.DataAccess.Context;
using Project.Entities.Entities;

namespace Project.DataAccess.Concrete;

public class UserRepository : RepositoryBase<User, ApplicationDbContext>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public IDataResult<User> GetUserByRToken(string refreshToken)
    {
        var user = _context.Users
    .Join(_context.RefreshTokens,
          user => user.Id,
          refreshToken => refreshToken.UserId,
          (user, refreshToken) => new { User = user, RefreshToken = refreshToken })
    .FirstOrDefault(joined => joined.RefreshToken.Token == refreshToken)
    ?.User;



        return new SuccessDataResult<User>(user);

    }

    public IDataResult<User> GetUser(string email)
    {
        var user = _context.Users
    .Join(_context.UserRoles,
          user => user.Id,
          userRole => userRole.UserId,
          (user, userRole) => new { User = user, UserRole = userRole })
    .Join(_context.Roles,
          joined => joined.UserRole.RoleId,
          role => role.Id,
          (joined, role) => new { joined.User, Role = role })
    .FirstOrDefault(joined => joined.User.EmailAddress == email).User;

        return new SuccessDataResult<User>(user);
    }

}
