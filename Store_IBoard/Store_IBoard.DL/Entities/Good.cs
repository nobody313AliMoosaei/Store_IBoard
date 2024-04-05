using System;
using System.Collections.Generic;

namespace Store_IBoard.DL.Entities;

public partial class Good
{
    public long Id { get; set; }

    public string? GoodName { get; set; }

    public string? GoodCode { get; set; }

    public string? GoodDescription { get; set; }

    public long? GoodPrice { get; set; }

    public long? GroupGoodRef { get; set; }

    public virtual ICollection<GoodsColor>? GoodsColors { get; set; } = new HashSet<GoodsColor>();

    public virtual GroupGood? GroupGoodRefNavigation { get; set; }
}
