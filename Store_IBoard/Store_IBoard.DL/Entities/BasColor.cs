using System;
using System.Collections.Generic;

namespace Store_IBoard.DL.Entities;

public partial class BasColor
{
    public long Id { get; set; }
    public string? PersianColorName { get; set; }
    public string? EnglishColorName { get; set; }
    public string? HexCode { get; set; }
    public int? ColorCode { get; set; }
    
    public virtual ICollection<GoodsColor> GoodsColors { get; set; } = new HashSet<GoodsColor>();
}
