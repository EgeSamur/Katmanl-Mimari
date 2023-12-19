using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO;

public class BillDetaiDto
{
    public string BillDate { get; set; }
    public string VKN { get; set; }
    public string BillNo { get; set; }
    public string TotalKdv { get; set; }
    public string Total { get; set; }

    public string CategoryName { get; set; }
}
