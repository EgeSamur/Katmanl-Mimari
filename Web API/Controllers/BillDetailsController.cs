using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.DTO;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BillDetailsController : Controller
    {
        private readonly IBillDetailService _billDetailService;

        public BillDetailsController(IBillDetailService billDetailService)
        {
            _billDetailService = billDetailService;
        }


        [HttpPost("create-bill_detail")]
        public IActionResult CreateBillDetail([FromBody] BillDetaiDto billDetaiDto)
        {
            var result = _billDetailService.CreateBillDetail(billDetaiDto);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete-bill_detail")]
        public IActionResult CreateBillDetail([FromQuery ]Guid id)
        {
            var result = _billDetailService.DeleteBillDetail(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("get_list-bill_detail")]
        public IActionResult GetListBillDetail([FromBody] FilterBillRequest filterBillDetail)
        {
            var result = _billDetailService.FilterBills(filterBillDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("get_totals-bill_detail")]
        public IActionResult GetTotalsBillDetail()
        {
            var result = _billDetailService.GetTotalForAMount();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
