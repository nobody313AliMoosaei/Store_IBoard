using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.DTO.OUTPUT.Admin
{
    public class GetOrdersDTO
    {
        public long? OrderId { get; set; }
        public string? OrderKey { get; set; }
        public long? OrderSerial { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public int CountUpdate { get; set; }
        public long? Status { get; set; }
        public string? StatusDsr { get; set; }
        public UserModelDTO? UserInfo { get; set; } = new UserModelDTO();
        public List<GoodModelDTO>? GoodOfOrders { get; set; } = new List<GoodModelDTO>();
    }

    public class UserModelDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NationalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; }
    }
    
    public class GoodModelDTO
    {
        public string? GoodName { get; set; }
        public string? GoodDescription { get; set; }
        public string? GoodCode { get; set; }
        public string? GoodCount { get; set; }
    }
}
