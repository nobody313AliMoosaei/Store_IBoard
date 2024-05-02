using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.Entities
{
    public class BasLookup
    {
        public long Id { get; set; }

        public string? Key { get; set; } = Guid.NewGuid().ToString();

        public string? Type { get; set; }

        public string? Title { get; set; }

        public string? Aux { get; set; }

        public ICollection<OrderHistory> OrderHistories { get; set; } = new HashSet<OrderHistory>();
        public virtual ICollection<Order>? Orders { get; set; } = new HashSet<Order>();
    }
}
