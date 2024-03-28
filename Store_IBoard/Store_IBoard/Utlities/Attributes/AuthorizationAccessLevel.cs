using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store_IBoard.DL.ToolsBLU;
using System.Net;
using System.Security.Claims;

namespace Store_IBoard.Utlities.Attributes
{
    public class AuthorizationAccessLevel : Attribute, IAuthorizationFilter
    {
        private readonly AccessLevel _access;
        public AuthorizationAccessLevel(AccessLevel acc)
        {
            _access = acc;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var _accessLevel = context.HttpContext.User.Claims.FirstOrDefault(e => e.Type == nameof(AccessLevel));
            if (_accessLevel is null)
                context.Result = new JsonResult("دسترسی برای شما تعریف نشده است");
            else if (_accessLevel.Value.Val32() != (int)_access)
                context.Result = new JsonResult("به این فرم دسترسی ندارید");

        }
    }
}
