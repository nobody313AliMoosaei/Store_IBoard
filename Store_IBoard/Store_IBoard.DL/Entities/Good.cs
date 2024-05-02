using System;
using System.Collections.Generic;

namespace Store_IBoard.DL.Entities;

public partial class Good
{
    public long Id { get; set; }

    public string? GoodName { get; set; }

    public string? GoodDescription { get; set; }

    public long? GoodPrice { get; set; }

    public ushort? Capacity { get; set; }

    public long? GroupGoodRef { get; set; }

    public string? GoodCode { get; set; }
    public ICollection<GoodImage> GoodImages { get; set; } = new HashSet<GoodImage>();
    public virtual ICollection<GoodOfOrder> GoodOfOrders { get; set; } = new List<GoodOfOrder>();

    public virtual ICollection<GoodsColor> GoodsColors { get; set; } = new List<GoodsColor>();

    public virtual GroupGood? GroupGoodRefNavigation { get; set; }
}
