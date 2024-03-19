using Store_IBoard.BL.DTO.INPUT.SignUp;
using Store_IBoard.BL.DTO.OUTPUT.SignUp;
using Store_IBoard.BL.Services.Public;

namespace Store_IBoard.BL.Services.SignUp
{
    public interface ISignUpService
    {
        Task<LoginModelDTO> Login(LoginDTO loginUser);
        Task<ErrorsVM> SignUp(SignUpDTO NewUser);
        Task<ErrorsVM> ForgetPassword(string? UserName);
        Task<ErrorsVM> ChangePassword(ChangePasswordModelDTO NewPassword);

    }
}
