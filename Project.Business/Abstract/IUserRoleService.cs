using Project.Common.Utilities.Results;
using Project.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Abstract
{
    public interface IUserRoleService
    {
        public IResult Add(UserRole userRole);
    }
}
