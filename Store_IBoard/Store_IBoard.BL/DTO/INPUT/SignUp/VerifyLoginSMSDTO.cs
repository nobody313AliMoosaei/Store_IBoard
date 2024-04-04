using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.DTO.INPUT.SignUp
{
    public class VerifyLoginSMSDTO
    {
        [RegularExpression("^(\\+98|0)?9\\d{9}$")]
        public string? Mobile { get; set; }
        public int Code { get; set; }
    }
}
