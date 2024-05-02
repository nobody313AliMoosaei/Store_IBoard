using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.Entities
{
    public class OrderHistory
    {
        public long? Id { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public long? StatusOrderRef { get; set; }
        public long? OrderRef { get; set; }
        public long? UserRef { get; set; }
        public string? Ip { get; set; }
        
        public Users? UserRefNavigation { get; set; }
        public BasLookup? StatusOrderRefNavigation { get; set; }
        public Order? OrderRefNavigation { get; set; }
    }
}
