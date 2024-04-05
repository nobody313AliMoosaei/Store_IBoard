using Store_IBoard.BL.Services.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

    }
}
