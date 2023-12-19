using Project.Business.Abstract;
using Project.Common.Paging;
using Project.Common.Utilities.Results;
using Project.DataAccess.Abstract;
using Project.DTO;
using Project.Entities.Entities;

namespace Project.Business.Concrete;


public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public IResult Add(CategoryDto categoryDto)
    {
        var result = CategoryIsExist(categoryDto);
        if (result.Success)
        {
            var category = new Category
            {
                Id = new Guid(),
                Name = categoryDto.Name
            };
            _categoryRepository.Add(category);
            return new SuccessResult("Category Created");
        }

        return new ErrorResult("Category Already Exist.");

    }

    public IResult Delete(CategoryDto categoryDto)
    {
        var category = _categoryRepository.Get(c => c.Name == categoryDto.Name);
        if (category != null)
        {
            _categoryRepository.Delete(category);
            return new SuccessResult("Category Deleted.");
        }

        return new ErrorResult();

    }

    public IResult CategoryIsExist(CategoryDto categoryDto)
    {
        var exist = _categoryRepository.Get(r => r.Name == categoryDto.Name);
        if (exist == null)
        {
            return new SuccessResult();
        }
        return new ErrorResult();
    }

    public IResult ListCategories()
    {
        
        var result = _categoryRepository.GetList();
        return new SuccessDataResult<IPaginate<Category>>(result);
    }
}
