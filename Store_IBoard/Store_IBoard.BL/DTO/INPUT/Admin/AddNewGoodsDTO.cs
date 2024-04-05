using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.DTO.INPUT.Admin
{
    public class AddNewGoodsDTO
    {
        [Required(ErrorMessage ="نام کالا را وارد کنید")]
        public string? GoodName { get; set; }
        [Required(ErrorMessage = "کد کالا را وارد کنید")]
        public string? GoodCode { get; set; }
        public string? GoodDsr { get; set; }
        [Required(ErrorMessage = "قیمت کالا را تعیین کنید")]
        public long GoodPrice { get; set; }
        [Required(ErrorMessage = "گروه بندی کالا را مشخص کنید")]
        public long GGRef { get; set; }
        public List<long>? ColorsRef { get; set; } = new List<long>();
    }
}
