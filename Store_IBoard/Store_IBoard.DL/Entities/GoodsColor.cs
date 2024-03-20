using System;
using System.Collections.Generic;

namespace Store_IBoard.DL.Entities;

public partial class GoodsColor
{
    public long Id { get; set; }

    public long? ColorRef { get; set; }

    public long? GoodRef { get; set; }

    public virtual BasColor? ColorRefNavigation { get; set; }

    public virtual Good? GoodRefNavigation { get; set; }
}
