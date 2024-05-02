using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.DTO.INPUT.Admin
{
    public class SearchOrders
    {
        public string? NationalCode { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? OrderSerial { get; set; }
        public string? OrderKey { get; set; }
        public FilterPagging Pageging { get; set; } = new FilterPagging();
    }
    public class FilterPagging
    {
        public int PageSize { get; set; } = 6;
        public int PageNumber { get; set; } = 1;
    }
}
