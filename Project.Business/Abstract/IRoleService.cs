

using Project.Common.Utilities.Results;
using Project.DTO;
using Project.Entities.Entities;

namespace Project.Business.Abstract;

public interface IRoleService
{
    public IResult Add(RoleDto role);
    public IResult Delete(RoleDto roleDto);
    public IDataResult<Role> GetUserRoles(Guid userId);
    public IDataResult<Role> GetRoleByName(string name);
    public IResult RoleIsExist(string name);

}
