using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store_IBoard.BL.DTO.INPUT.SignUp;
using Store_IBoard.BL.Services.SignUp;
using System.Globalization;

namespace Store_IBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private ISignUpService _signUpService;
        public SignUpController(ISignUpService signupservice)
        {
            _signUpService = signupservice;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginDTO LoginModel)
        {
            var Result = await _signUpService.Login(LoginModel);
            if (Result.Error.IsValid)
                return Ok(Result);
            return BadRequest(Result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(SignUpDTO NewUserModel)
        {
            var Result = await _signUpService.Register(NewUserModel);
            if (Result.IsValid) return Ok(Result);
            return BadRequest(Result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ForgetPassword(string UserName)
        {
            var Result = await _signUpService.ForgetPassword(UserName);
            if (Result.IsValid) return Ok(Result);
            return BadRequest(Result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPassword([FromBody] ChangePasswordModelDTO Date)
        {
            var Result = await _signUpService.ChangePassword(Date);
            if (Result.IsValid) return Ok(Result);
            return BadRequest(Result);
        }

    }
}
