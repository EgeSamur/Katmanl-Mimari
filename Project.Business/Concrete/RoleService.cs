
using Project.Business.Abstract;
using Project.Common.Utilities.Results;
using Project.DataAccess.Abstract;
using Project.DTO;
using Project.Entities.Entities;

namespace Project.Business.Concrete;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    public RoleService(IRoleRepository roleRepository,IUserRoleRepository userRoleRepository)
    {
        
        _roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;
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
}
