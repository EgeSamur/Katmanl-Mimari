using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO;

public class ForTotal
{
    public Guid CategoryId { get; set; }
    public DateTime? BillDateStart { get; set; }
    public DateTime? BillDateEnd { get; set; }
}
