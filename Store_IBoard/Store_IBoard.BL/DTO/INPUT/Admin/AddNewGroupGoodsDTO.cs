using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.DTO.INPUT.Admin
{
    public class AddNewGroupGoodsDTO
    {
        [Required(ErrorMessage = "وارد کردن نام اجباری است")]
        public string? GGname { get; set; }
        [Required(ErrorMessage ="دسته بندی را مشخص کنید")]
        [Range(long.MaxValue,1)]
        public long CategoryRef { get; set; }
    }
}
