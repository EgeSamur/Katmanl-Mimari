

using Project.Common.Paging;
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

    public IDataResult<List<UserAndRoleDto>> GetAllRolesAndUsers();
    public IDataResult<IPaginate<Role>> GetAllRoles(int index, int size);
    public IResult RoleIsExist(string name);

}
