using Store_IBoard.BL.DTO.INPUT.SignUp;
using Store_IBoard.BL.DTO.OUTPUT.SignUp;
using Store_IBoard.BL.Services.Public;

namespace Store_IBoard.BL.ApplicationBusiness.SignUp
{
    public interface ISignUpService
    {
        Task<LoginModelDTO> Login(LoginDTO loginUser);
        Task<ErrorsVM> LoginByMobile(string Mobile);
        Task<LoginModelDTO> VerifyLoginByMobile(VerifyLoginSMSDTO loginUser);
        Task<ErrorsVM> Register(SignUpDTO NewUser);
        Task<ErrorsVM> ForgetPassword(string? UserName);
        Task<ErrorsVM> ChangePassword(ChangePasswordModelDTO NewPassword);
        Task<ErrorsVM> IsAdmin(long UserId);
        Task<ErrorsVM> IsAdmin(string UserName);

    }
}
