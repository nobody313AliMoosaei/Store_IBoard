using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store_IBoard.BL.DTO.INPUT.SignUp;
using Store_IBoard.BL.DTO.OUTPUT.SignUp;
using Store_IBoard.BL.Services.JWT;
using Store_IBoard.BL.Services.Public;
using Store_IBoard.DL.ApplicationDbContext;
using Store_IBoard.DL.Entities;
using Store_IBoard.DL.ToolsBLU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.Services.SignUp
{
    public class SignUpService : ISignUpService
    {
        private ApplicationDbContext _context;
        private IJWTTokenManager _jwtTokenManager;
        private UserManager<Users> _userManager;
        public SignUpService(ApplicationDbContext context,
            IJWTTokenManager jwtmanager
            ,UserManager<Users> usermanager)
        {
            _context = context;
            _jwtTokenManager = jwtmanager;
            _userManager = usermanager;
        }
        public Task<ErrorsVM> ChangePassword(ChangePasswordModelDTO NewPassword)
        {
            // Verify SMS And ChangePassword
            throw new NotImplementedException();
        }

        public Task<ErrorsVM> ForgetPassword(string? UserName)
        {
            // Send SMS
            throw new NotImplementedException();
        }

        public async Task<LoginModelDTO> Login(LoginDTO loginUser)
        {
            var res = new LoginModelDTO();
            try
            {
                if (loginUser is null || loginUser.UserName.IsNullOrEmpty() || loginUser.Password.IsNullOrEmpty())
                    res.Error.Message = "نام کاربری یا رمز عبور پر نشده است";
                else
                {
                    var user = await _context.Users.Where(e => e.UserName == loginUser.UserName
                    || e.PhoneNumber == loginUser.UserName || e.Email == loginUser.UserName)
                        .FirstOrDefaultAsync();

                    if (user is null)
                        res.Error.Message = "کاربری یافت نشد";
                    else
                    {
                        if(!await _userManager.CheckPasswordAsync(user, loginUser.Password))
                            res.Error.Message = "نام کاربری معتبر نیست";
                        else
                        {
                            var RolesUser = await _userManager.GetRolesAsync(user);
                            res.FullName = user.FirstName + " " + user.LastName;
                            res.UserName = user.UserName;
                            res.Token = _jwtTokenManager.GetUserToken(user.Id, user.UserName, RolesUser);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.Error.Message = "خطا در اجرای برنامه";
                res.Error.LstErrors.Add(ex.Message);
                if(ex.InnerException is not null)
                    res.Error.LstErrors.Add(ex.InnerException.Message);
            }
            return res;
        }

        public async Task<ErrorsVM> SignUp(SignUpDTO NewUser)
        {
            var res = new ErrorsVM();
            try
            {
                if (NewUser is null || NewUser.PhoneNumber.IsNullOrEmpty() || NewUser.NationalCode.IsNullOrEmpty()
                    || NewUser.FirstName.IsNullOrEmpty() || NewUser.LastName.IsNullOrEmpty() || (NewUser.Password != NewUser.ConfirmPassword))
                    res.Message = "اطلاعات ارسالی ناقص است";
                else
                {
                    // check NationalCode And UserName And PhoneNumber
                    if (await _context.Users.AnyAsync(e => e.UserName == NewUser.PhoneNumber
                    || e.PhoneNumber == NewUser.PhoneNumber || e.NationalCode == NewUser.NationalCode))
                        res.Message = "کاربری با این مشخصات در سیستم ثبت شده است";
                    else
                    {
                        var user = new Users
                        {
                            FirstName = NewUser.FirstName,
                            LastName = NewUser.LastName,
                            PhoneNumber = NewUser.PhoneNumber,
                            UserName = NewUser.PhoneNumber,
                            NationalCode = NewUser.NationalCode,
                            UserStatus = UserStatus.Accept,
                            Email = NewUser.Email,
                            IsActive = true
                        };
                        if((await _userManager.CreateAsync(user, NewUser.Password)).Succeeded)
                        {
                            // Add Defualt Role
                            if ((await _userManager.AddToRoleAsync(user, UserRoles.DefulatUser.ToString())).Succeeded)
                            {
                                res.Message = "کاربر با موفقیت ایجاد شد";
                                res.IsValid = true;
                            }
                            else
                                res.Message = "اختصاص نقش به کاربر امکان پذیر نیست";
                        }
                        else
                            res.Message = "این کاربر نمی تواند در سیستم ثبت نام کند";
                    }
                }
            }catch (Exception ex)
            {
                res.Message = "خطا در اجرای برنامه";
                res.LstErrors.Add(ex.Message);
                if (ex.InnerException is not null)
                    res.LstErrors.Add(ex.InnerException.Message);
            }
            return res;
        }
    }
}
