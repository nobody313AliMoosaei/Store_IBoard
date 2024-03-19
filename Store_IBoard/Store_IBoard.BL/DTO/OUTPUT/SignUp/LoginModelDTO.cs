using Store_IBoard.BL.Services.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.DTO.OUTPUT.SignUp
{
    public class LoginModelDTO
    {
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? Token { get; set; }
        public ErrorsVM Error { get; set; } = new ErrorsVM();
    }
}
