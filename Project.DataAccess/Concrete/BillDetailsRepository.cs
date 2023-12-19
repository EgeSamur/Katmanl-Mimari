using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete.Base;
using Project.DataAccess.Context;
using Project.Entities.Entities;

namespace Project.DataAccess.Concrete;

public class BillDetailsRepository : RepositoryBase<BillDetails, ApplicationDbContext>, IBillDetailsRepository
{
    public BillDetailsRepository(ApplicationDbContext context) : base(context)
    {
    }
}