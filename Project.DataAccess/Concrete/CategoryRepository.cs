using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete.Base;
using Project.DataAccess.Context;
using Project.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Concrete;

public class CategoryRepository : RepositoryBase<Category, ApplicationDbContext>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
