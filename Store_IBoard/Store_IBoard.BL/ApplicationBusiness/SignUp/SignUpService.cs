using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store_IBoard.BL.DTO.INPUT.SignUp;
using Store_IBoard.BL.DTO.OUTPUT.SignUp;
using Store_IBoard.BL.Services.Eamil;
using Store_IBoard.BL.Services.JWT;
using Store_IBoard.BL.Services.Public;
using Store_IBoard.BL.Services.SMS;
using Store_IBoard.DL.ApplicationDbContext;
using Store_IBoard.DL.Entities;
using Store_IBoard.DL.ToolsBLU;
using Store_IBoard.DL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.ApplicationBusiness.SignUp
{
    public class SignUpService : ISignUpService
    {
        private ApplicationDBContext _context;
        private IJWTTokenManager _jwtTokenManager;
        private UserManager<Users> _userManager;
        private IEmailService _emailService;
        private ISMS _SMS;
        private RepositoryGeneric<SendEmailSMSModel> _sendEmSMRepo;
        public SignUpService(ApplicationDBContext context,
            IJWTTokenManager jwtmanager,
            UserManager<Users> usermanager,
            IEmailService emailservice,
            RepositoryGeneric<SendEmailSMSModel> sendEmSMRepo,
            ISMS sms)
        {
            _context = context;
            _jwtTokenManager = jwtmanager;
            _userManager = usermanager;
            _emailService = emailservice;
            _sendEmSMRepo = sendEmSMRepo;
            _SMS = sms;
        }

        public async Task<ErrorsVM> ChangePassword(ChangePasswordModelDTO NewPassword)
        {
            var res = new ErrorsVM();
            try
            {
                #region Validations
                if (NewPassword is null)
                    res.AddError("ارسال اطلاعات ناقص است");
                if (NewPassword.UserName.IsNullOrEmpty())
                    res.AddError("وارد کردن نام کاربری اجباری است");
                if (NewPassword.Password.IsNullOrEmpty() || NewPassword.ConfirmPassword.IsNullOrEmpty())
                    res.AddError("وارد کردن رمز عبور اجباری است");
                if (NewPassword.Password != NewPassword.ConfirmPassword)
                    res.AddError("رمز عبور با تکرار رمز عبور یکسان نیست");

                if (res.LstErrors.Count > 0)
                    res.Message = "اطلاعات برای تغییر رمز معتبر نیست";
                #endregion
                else
                {
                    // Verify SMS And ChangePassword
                    // --

                    // Send Email Verify
                    var user = await _context.Users.Where(e => e.UserName == NewPassword.UserName ||
                                                    e.Email == NewPassword.UserName || e.PhoneNumber == NewPassword.UserName)
                        .FirstOrDefaultAsync();
                    if (user is null)
                        res.Message = "کاربری با این مشخصات وجود ندارد";
                    else
                    {
                        var lstSends = await _context.SendEmailSMSModels.Where(e => (e.PhoneNumber == user.PhoneNumber
                        || e.Email == user.Email) && e.Code == NewPassword.Code && e.InsertDateTime.Value.AddMinutes(3) >= DateTime.Now)
                            .ToListAsync();
                        if (lstSends.Count > 0)
                        {
                            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, NewPassword.Password);
                            res.Message = "رمز با موفقيت تغییر یافت";
                            res.IsValid = true;
                        }
                        else
                            res.Message = "کد اشتباه است";
                    }
                }
            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;
        }

        public async Task<ErrorsVM> ForgetPassword(string? UserName)
        {
            var res = new ErrorsVM();
            try
            {
                if (UserName.IsNullOrEmpty())
                    res.Message = "نام کاربری وارد نشده است";
                else
                {
                    // Send SMS
                    //--


                    // Send Email

                    var user = await _context.Users.Where(e => e.UserName == UserName
                    || e.PhoneNumber == UserName || e.Email == UserName || e.NationalCode == UserName)
                        .FirstOrDefaultAsync();
                    if (user is null)
                        res.Message = "کاربری با این مشخصات وجود ندارد";
                    else
                    {
                        var random = new Random();
                        int key = random.Next(100000, 999999);
                        string body = $"Code = {key}";
                        _sendEmSMRepo.InsertEntity(new SendEmailSMSModel
                        {
                            Code = key,
                            Email = user.Email,
                            PhoneNumber = user.PhoneNumber
                        });

                        Task.Factory.StartNew(() => _emailService.SendYahooMailAsync(user.Email, body));
                    }
                }
            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;
        }

        public async Task<ErrorsVM> IsAdmin(long UserId)
        {
            var res = new ErrorsVM();
            try
            {
                if (UserId > 0)
                {
                    var user = await _context.Users.Where(e => e.Id == UserId).FirstOrDefaultAsync();
                    if (user is null)
                        res.Message = "کاربر يافت نشد";
                    else
                    {
                        if ((await _userManager.GetRolesAsync(user)).Any(e => e.ToLower() == UserRoles.Administrator.ToString().ToLower()))
                        {
                            res.Message = "کاربر داری نقش ادمین می باشد";
                            res.IsValid = true;
                        }
                        else
                        {
                            res.Message = "کاربر دارای نقش ادمین نمی باشد";
                        }
                    }
                }
                else
                    res.Message = "شناسه کاربر معتبر نمی‌باشد";
            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;
        }

        public async Task<ErrorsVM> IsAdmin(string UserName)
        {

            var res = new ErrorsVM();
            try
            {
                if (!UserName.IsNullOrEmpty())
                {
                    var user = await _context.Users
                        .Where(e => e.UserName == UserName
                        || e.PhoneNumber == UserName || e.NormalizedUserName == UserName
                        || e.NormalizePhoneNumber == UserName || e.NationalCode == UserName).FirstOrDefaultAsync();
                    if (user is null)
                        res.Message = "کاربر يافت نشد";
                    else
                    {
                        if ((await _userManager.GetRolesAsync(user)).Any(e => e.ToLower() == UserRoles.Administrator.ToString().ToLower()))
                        {
                            res.Message = "کاربر داری نقش ادمین می باشد";
                            res.IsValid = true;
                        }
                        else
                        {
                            res.Message = "کاربر دارای نقش ادمین نمی باشد";
                        }
                    }
                }
                else
                    res.Message = "نام کاربری، کاربر معتبر نمی‌باشد";
            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;
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
                        if (!await _userManager.CheckPasswordAsync(user, loginUser.Password))
                            res.Error.Message = "نام کاربری معتبر نیست";
                        else
                        {
                            var RolesUser = await _userManager.GetRolesAsync(user);
                            res.FullName = user.FirstName + " " + user.LastName;
                            res.UserName = user.UserName;
                            res.Token = _jwtTokenManager.GetUserToken(user.Id, user.UserName, RolesUser);
                            res.Error.IsValid = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.Error.ExceptionError(ex);
            }
            return res;
        }

        public async Task<ErrorsVM> LoginByMobile(string Mobile)
        {
            ErrorsVM res = new ErrorsVM();
            try
            {
                var user = await _context.Users.Where(e => e.PhoneNumber == Mobile || e.UserName == Mobile).FirstOrDefaultAsync();
                if (user is null)
                {
                    res.Message = "کاربری یافت نشد";
                    res.AddError("لطفا ثبت نام کنید");
                }
                else
                {
                    int key = ExtentionsSystem.RandoNumber6();

                    var resultSMS = await _SMS.SendSMS(Mobile, $"کد ورود به IBoard : {key}", user.Id);
                    if (!resultSMS.IsValid)
                        res = resultSMS;
                    else
                        await _sendEmSMRepo.InsertEntity(new SendEmailSMSModel
                        {
                            Code = key,
                            PhoneNumber = Mobile,
                            InsertDateTime = DateTime.Now,
                        });
                    res.Message = "پیامک ارسال شد";
                    res.IsValid = true;
                }
            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;
        }

        public async Task<LoginModelDTO> VerifyLoginByMobile(VerifyLoginSMSDTO loginUser)
        {
            LoginModelDTO res = new LoginModelDTO();
            try
            {
                if (!await _context.SendEmailSMSModels.Where(e => e.PhoneNumber == loginUser.Mobile && e.Code == loginUser.Code
                && e.InsertDateTime.Value.AddMinutes(3) >= DateTime.Now).AnyAsync())
                    res.Error.Message = "کد معتبر نمی باشد";
                else
                {
                    var user = await _context.Users.Where(e => e.PhoneNumber == loginUser.Mobile || e.UserName == loginUser.Mobile)
                        .FirstOrDefaultAsync();
                    if (user is null)
                        res.Error.Message = "کاربری یافت نشد";
                    else
                    {
                        var Roles = await _userManager.GetRolesAsync(user);
                        res.Token = _jwtTokenManager.GetUserToken(user.Id, user.UserName, Roles);
                        res.UserName = user.UserName;
                        res.FullName = user.FirstName + " " + user.LastName;
                        res.Error.IsValid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                res.Error.ExceptionError(ex);
            }
            return res;
        }

        public async Task<ErrorsVM> Register(SignUpDTO NewUser)
        {
            var res = new ErrorsVM();
            try
            {
                if (NewUser is null || NewUser.PhoneNumber.IsNullOrEmpty() || NewUser.NationalCode.IsNullOrEmpty()
                    || NewUser.FirstName.IsNullOrEmpty() || NewUser.LastName.IsNullOrEmpty() || NewUser.Password != NewUser.ConfirmPassword)
                    res.Message = "اطلاعات ارسالی ناقص است";
                else
                {
                    // check NationalCode And UserName And PhoneNumber
                    if (await _context.Users.AnyAsync(e => e.UserName == NewUser.PhoneNumber
                    || e.PhoneNumber == NewUser.PhoneNumber || e.NationalCode == NewUser.NationalCode))
                        res.Message = "کاربری با این مشخصات در سیستم ثبت شده است";
                    else
                    {
                        string Normalize_PhoneNumber = NewUser.PhoneNumber;
                        if (NewUser.PhoneNumber.StartsWith("+98"))
                            Normalize_PhoneNumber = NewUser.PhoneNumber.Replace("+98", "0");
                        //else if (NewUser.PhoneNumber.StartsWith("98"))
                        //    Normalize_PhoneNumber = "0"+NewUser.PhoneNumber.Substring(1);
                        var user = new Users
                        {
                            FirstName = NewUser.FirstName,
                            LastName = NewUser.LastName,
                            PhoneNumber = NewUser.PhoneNumber,
                            UserName = Normalize_PhoneNumber,

                            NationalCode = NewUser.NationalCode,
                            UserStatus = UserStatus.Accept,
                            Email = NewUser.Email,
                            IsActive = true
                        };

                        if ((await _userManager.CreateAsync(user, NewUser.Password)).Succeeded)
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
            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;
        }

    }
}
