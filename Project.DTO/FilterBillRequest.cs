using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO;

public class FilterBillRequest
{
    public Guid? CategoryId { get; set; }
    public DateTime? BillDateStart { get; set; }
    public DateTime? BillDateEnd { get; set; }
    public decimal TotalKDVMax { get; set; }
    public decimal TotalKDVMin { get; set; }
    public decimal TotalMax { get; set; }
    public decimal TotalMin { get; set; }
}
