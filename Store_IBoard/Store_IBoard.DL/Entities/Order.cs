using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.Entities
{
    public class Order
    {
        public long Id { get; set; }

        public DateTime? CreateDateTime { get; set; } = DateTime.Now;

        public DateTime? UpdateDateTime { get; set; } = DateTime.Now;

        public long? OrderSerial { get; set; }

        public string? OrderKey { get; set; }

        public int CountUpdate { get; set; }

        public long StatusOrderRef { get; set; }

        public long? UserRef { get; set; }

        public virtual ICollection<GoodOfOrder> GoodOfOrders { get; set; } = new List<GoodOfOrder>();

        public virtual Users? UserRefNavigation { get; set; }

        public virtual BasLookup? StatusOrderRefNavigation { set; get; }
        public ICollection<OrderHistory> OrderHistories { get; set; } = new HashSet<OrderHistory>();
    }
}
