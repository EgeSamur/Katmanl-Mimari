using Project.Business.Abstract;
using Project.Common.Utilities.Results;
using Project.DataAccess.Abstract;
using Project.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Concrete;

public class UserRoleService : IUserRoleService
{
    public readonly IUserRoleRepository _userRoleRepository;

    public UserRoleService(IUserRoleRepository userRoleRepository)
    {
        
        _userRoleRepository = userRoleRepository;
    }
    public IResult Add(UserRole userRole)
    {
        _userRoleRepository.Add(userRole);
        return new SuccessResult("UserRole Created.");
    }
}
