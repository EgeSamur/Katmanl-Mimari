using Project.Entities.Base;

namespace Project.Entities.Entities;

public class BillDetails : BaseEntity
{
    public DateTime BillDate { get; set; }
    public string VKN { get; set; }
    public string BillNo { get; set; }
    public decimal TotalKdv { get; set; }
    public decimal Total { get; set; }

    // 
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}



