using System;
using System.Collections.Generic;

namespace Store_IBoard.DL.Entities;

public partial class GroupGood
{
    public long Id { get; set; }

    public string? GroupName { get; set; }

    public long? CategoryRef { get; set; }

    public virtual Category? CategoryRefNavigation { get; set; }

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
}
