using Project.Common.Utilities.Results;
using Project.DTO;
using Project.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Abstract;

public interface ICategoryService
{
    public IResult Add(CategoryDto categoryDto);
    public IResult Delete(CategoryDto categoryDto);

    public IResult ListCategories();

    
}
