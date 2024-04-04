using Store_IBoard.DL.ToolsBLU;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.Entities
{
    public class HistorySendSMS
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public long? UserRef { get; set; }
        public string? Mobile { get; set; }
        public string? Message { get; set; }
        public DateTime? InsertDateTime { get; set; } = DateTime.Now.ToPersianDateTime();
        public string? Ip { get; set; }
        public string? Client { get; set; }

        //[ForeignKey(nameof(UserRef))]
        public Users? UserRefNavigation { get; set; }
    }
}
