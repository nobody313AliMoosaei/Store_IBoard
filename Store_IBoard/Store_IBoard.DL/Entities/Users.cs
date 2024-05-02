using Microsoft.AspNetCore.Identity;
using Store_IBoard.DL.ToolsBLU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.Entities
{
    public class Users : IdentityUser<long>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NationalCode { get; set; }
        public bool IsActive { get; set; } = true;
        public UserStatus UserStatus { get; set; }
        public AccessLevel AccessLevel { get; set; } = AccessLevel.None;
        public string? NormalizePhoneNumber { get; set; }

        public ICollection<HistorySendSMS>? HistorySms { get; set; } = new HashSet<HistorySendSMS>();
        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<OrderHistory> OrderHistories { get; set; } = new HashSet<OrderHistory>();
    }
}
