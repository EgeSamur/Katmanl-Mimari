using Project.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public Category()
    {

    }

    public Category(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public ICollection<BillDetails> BillDetails { get; set; }
}



