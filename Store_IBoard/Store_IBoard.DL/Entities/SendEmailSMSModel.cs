using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.Entities
{
    public class SendEmailSMSModel
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int Code { get; set; }
        public DateTime? InsertDateTime { get; set; } = DateTime.Now;
    }
}
