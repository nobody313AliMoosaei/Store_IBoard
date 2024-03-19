using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.DTO.INPUT.SignUp
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="وارد کردن نام کاربری اجباری است")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "وارد کردن رمز عبور اجباری است")]
        public string? Password { get; set; }
        public bool IsRemember { get; set; } = true;
    }
}
