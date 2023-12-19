using Project.Common.Utilities.Results;
using Project.DTO;
using Project.Entities.Entities;

namespace Project.Business.Abstract;

public interface IBillDetailService
{
    public IDataResult<BillDetails> CreateBillDetail(BillDetaiDto billDetaiDto);
    public IResult DeleteBillDetail(Guid id);

    public IResult FilterBills(FilterBillRequest request);
    //public IResult UpdateBillDetail(BillDetaiDto billDetaiDto);
    public IResult GetTotalForAMount();




    // Listeleme Filtreleme vs vs olcak.


}
