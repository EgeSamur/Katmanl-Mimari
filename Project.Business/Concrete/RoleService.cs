
using Project.Business.Abstract;
using Project.Common.Paging;
using Project.Common.Utilities.Results;
using Project.DataAccess.Abstract;
using Project.DTO;
using Project.Entities.Entities;

namespace Project.Business.Concrete;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUserRepository _userRepository;

    public RoleService(IRoleRepository roleRepository,IUserRoleRepository userRoleRepository,IUserRepository userRepository)
    {
        
        _roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;
        _userRepository = userRepository;
    }
    public IResult Add(RoleDto roleDto)
    {
        var result = RoleIsExist(roleDto.Name);
        if(result.Success == true)
        {
            var role = new Role
            {
                Id = new Guid(),
                Name = roleDto.Name
            };
            _roleRepository.Add(role);
            return new SuccessResult("Role Created.");
            
        }
        return new ErrorResult("Role already exist.");

    }

    public IResult Delete(RoleDto roleDto)
    {
        
          var role = _roleRepository.Get(r => r.Name == roleDto.Name);
        if(role != null)
        {
            _roleRepository.Add(role);
            return new SuccessResult("Role Deleted.");
        }
        return new ErrorResult("Role Does not exist.");





    }

    public IDataResult<Role> GetRoleByName(string name)
    {
       var role = _roleRepository.Get(r => r.Name == name);
        return new SuccessDataResult<Role>(role);
    }

    public IDataResult<Role> GetUserRoles(Guid userId)
    {
        var userRoles = _userRoleRepository.Get(r => r.UserId == userId);
        var role = _roleRepository.Get(r => r.Id == userRoles.RoleId);
        //var role = userRoles.Role;
        return new SuccessDataResult<Role>(role);
    }

    public IResult RoleIsExist(string name)
    {
        var exist = _roleRepository.Get(r  => r.Name == name);
        if (exist == null)
        {
            return new SuccessResult();
        }
        return new ErrorResult();
    }

    public IDataResult<IPaginate<Role>> GetAllRoles(int index, int size)
    {
        var roles = _roleRepository.GetList(index: index, size: size);
        if(roles != null)
            return new SuccessDataResult<IPaginate<Role>>(roles);
        return new ErrorDataResult<IPaginate<Role>>("Someting Went Wrong.");
    }

    public IDataResult<List<UserAndRoleDto>> GetAllRolesAndUsers()
    {
        var roleAndUsers = new List<UserAndRoleDto>();
        var roles = _roleRepository.GetList(index: 0, size: 99999).Items;
        if(roles != null)
        {
            foreach( var role in roles)
            {
                var userRoles = _userRoleRepository.GetList(i=>i.RoleId == role.Id).Items;
                foreach( var userId in userRoles)
                {
                    var user = _userRepository.Get(i => i.Id == userId.UserId);
                    var userAndRole = new UserAndRoleDto
                    {
                        UserEmail = user.EmailAddress,
                        RoleName = role.Name,
                    };
                    roleAndUsers.Add(userAndRole);
                }
            }
            return new SuccessDataResult<List<UserAndRoleDto>>(roleAndUsers);
        }
        return new ErrorDataResult<List<UserAndRoleDto>>("Someting Went Wrong.");
        
    }
}
