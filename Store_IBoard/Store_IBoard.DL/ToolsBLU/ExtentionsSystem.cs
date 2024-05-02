using Store_IBoard.BL.Services.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.ToolsBLU
{
    public static class ExtentionsSystem
    {
        public static bool IsNullOrEmpty(this string? Value)
        {
            try
            {
                if (Value is null || string.IsNullOrEmpty(Value) || string.IsNullOrWhiteSpace(Value)
                    || string.IsNullOrWhiteSpace(Value.Trim()))
                    return true;
                return false;
            }
            catch
            {
                return true;
            }
        }

        public static void AddError(this ErrorsVM res, string message)
        {
            if (res.LstErrors is null)
                res.LstErrors = new List<string>();
            res.LstErrors.Add(message);
        }
        public static void ExceptionError(this ErrorsVM res, Exception ex)
        {
            if(ex is not null)
            {
                res.Message = "خطا در اجرای برنامه";
                res.AddError(ex.Message);
                if (ex.InnerException is not null)
                    res.AddError(ex.InnerException.Message);
            }
        }

        public static DateTime ToPersianDateTime(this DateTime Value)
        {
            System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();

            return new DateTime(persianCalendar.GetYear(Value), persianCalendar.GetMonth(Value)
                , persianCalendar.GetDayOfMonth(Value), persianCalendar.GetHour(Value),
                persianCalendar.GetMinute(Value), persianCalendar.GetSecond(Value));
        }

        public static long Val64(this string? Value)
        {
            long num = -3333;
            long.TryParse(Value, out num);
            return num;
        }

        public static double Val72(this string? Value)
        {
            double num = -3333;
            double.TryParse(Value, out num);
            return num;
        }

        public static int Val32(this string? Value)
        {
            int num = -3333;
            int.TryParse(Value, out num);
            return num;
        }

        public static byte Val16(this string? Value)
        {
            byte num;
            byte.TryParse(Value, out num);
            return num;
        }
        public static int RandoNumber6()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }

        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            ParameterExpression param = expr1.Parameters[0];
            if (ReferenceEquals(param, expr2.Parameters[0]))
                return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, expr2.Body), param);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, Expression.Invoke(expr2, param)), param);
        }

        public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            ParameterExpression param = expr1.Parameters[0];
            if (ReferenceEquals(param, expr2.Parameters[0]))
                return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, expr2.Body), param);

            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, Expression.Invoke(expr2, param)), param);
        }


        public static string EncryptString(this string text, string? keyString = null)
        {
            if (keyString.IsNullOrEmpty())
                keyString = SystemConsts.PrivateKey;
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
                {
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }

                        var iv = aesAlg.IV;

                        var decryptedContent = msEncrypt.ToArray();

                        var result = new byte[iv.Length + decryptedContent.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        public static string DecryptString(this string cipherText, string? keyString = null)
        {
            if(keyString.IsNullOrEmpty())
                keyString = SystemConsts.PrivateKey;

            var fullCipher = Convert.FromBase64String(cipherText);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
            var key = Encoding.UTF8.GetBytes(keyString);

            using (var aesAlg = Aes.Create())
            {
                using (var decryptor = aesAlg.CreateDecryptor(key, iv))
                {
                    string result;
                    using (var msDecrypt = new MemoryStream(cipher))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                result = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }
    }
}
