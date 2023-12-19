using Project.Common.Utilities.Results;
using Project.DataAccess.Abstract;
using Project.DataAccess.Context;
using Project.DTO;
using Project.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Concrete.Base;

public class RoleRepository:RepositoryBase<Role, ApplicationDbContext> , IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context)
    {

    }


}
