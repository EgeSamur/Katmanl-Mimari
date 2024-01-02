using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.DTO;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    //[Authorize]
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
        public IActionResult GetListBillDetail([FromBody] FilterBillRequest filterBillDetail, [FromQuery] int index)
        {
            var result = _billDetailService.FilterBills(filterBillDetail,index);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("get_list-bill_detailNEW")]
        public IActionResult GetListBillDetail()
        {

           
            var result = _billDetailService.GetBillDetailsBills();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("get_totals-bill_detail")]
        public IActionResult GetTotalsBillDetail([FromBody] ForTotal fortotal)
        {
            var result = _billDetailService.GetTotalForAMount(fortotal);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get_totals-bill_detail_for_categories")]
        public IActionResult GetBillsTotalForCategories()
        {
            var result = _billDetailService.GetBillsAmountForCategories();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
