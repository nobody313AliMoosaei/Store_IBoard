using System;
using System.Collections.Generic;

namespace Store_IBoard.DL.Entities;

public partial class Category
{
    public long Id { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<GroupGood> GroupGoods { get; set; } = new List<GroupGood>();
}
