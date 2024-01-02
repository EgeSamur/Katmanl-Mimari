using Project.Common.Paging;
using Project.Common.Utilities.Results;
using Project.DTO;
using Project.Entities.Entities;

namespace Project.Business.Abstract;

public interface IBillDetailService
{
    public IDataResult<BillDetails> CreateBillDetail(BillDetaiDto billDetaiDto);
    public IResult DeleteBillDetail(Guid id);
    public IResult FilterBills(FilterBillRequest request, int index = 0, int size = 10);
    public IResult GetBillDetailsBills();

    public IResult GetBillsAmountForCategories();
    public IResult GetBillsAmountForRoles();
    //public IResult FilterBills(FilterBillRequest request);
    //public IResult UpdateBillDetail(BillDetaiDto billDetaiDto);
    public IResult GetTotalForAMount(ForTotal fortTotal);




    // Listeleme Filtreleme vs vs olcak.


}
