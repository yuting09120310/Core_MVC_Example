using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core_MVC_Example.Areas.BackEnd.Filter
{
	public class AuthFilter : IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			var controllerName = context.RouteData.Values["Controller"];
			var actionName = context.RouteData.Values["Action"];


			string GroupNum = context.HttpContext.Session.GetString("GroupNum");
			string AdminName = context.HttpContext.Session.GetString("AdminName");
			string AdminNum = context.HttpContext.Session.GetString("AdminNum");

			// 判斷使用者是否登入            
			if (string.IsNullOrEmpty(GroupNum) || string.IsNullOrEmpty(AdminName) || string.IsNullOrEmpty(AdminNum))
			{
				//context.Result = new RedirectToActionResult("Index", "Login", null);
				context.Result = new ContentResult()
				{
					Content = "<script>alert('123');window.location.href='/Backend/Login/Index'</script>",
					ContentType = "text/html;charset=utf-8",
				};

				return;

			}
		}
	}
}
