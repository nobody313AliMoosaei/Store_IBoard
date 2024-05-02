using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.Entities
{
    public class GoodOfOrder
    {
        public long Id { get; set; }

        public int? GoodCount { get; set; }

        public double? GoodPrice { get; set; }

        public DateTime? CreateDateTime { get; set; } = DateTime.Now;


        public long? GoodRef { get; set; }

        public long? OrderRef { get; set; }

        public virtual Good? GoodRefNavigation { get; set; }

        public virtual Order? OrderRefNavigation { get; set; }
    }
}
