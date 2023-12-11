

using Project.Entities.Base;

namespace Project.Entities.Entities;

public class Role:BaseEntity
{
    public string Name { get; set; }

    public Role(Guid id , string name)
    {
        Id = id;
        Name = name;
    }
}

