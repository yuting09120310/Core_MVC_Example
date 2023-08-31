using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OBizCommonClass;
using System.Data;

namespace Core_MVC_Example.Areas.BackEnd.Attribute
{
	public class AuthFilter : IAuthorizationFilter
	{
		public Basic _basic;

		public AuthFilter(Basic basic)
		{
			_basic = basic;
		}

		public void OnAuthorization(AuthorizationFilterContext context)
		{

			string GroupNum = context.HttpContext.Session.GetString("GroupNum");
			string AdminName = context.HttpContext.Session.GetString("AdminName");
			string AdminNum = context.HttpContext.Session.GetString("AdminNum");

			if (string.IsNullOrEmpty(GroupNum) || string.IsNullOrEmpty(AdminName) || string.IsNullOrEmpty(AdminNum))
			{
				context.Result = new ContentResult()
				{
					Content = "<script>alert('尚未登入');window.location.href='/Backend/Login/Index'</script>",
					ContentType = "text/html;charset=utf-8",
				};

				return;
			}

			string controllerName = context.RouteData.Values["Controller"].ToString();
			string actionName = context.RouteData.Values["Action"].ToString();

			if (controllerName != "Home")
			{
				Dictionary<string, string> dic = new Dictionary<string, string>();
				dic.Add("Create", "C");
				dic.Add("Index", "R");
				dic.Add("Edit", "U");
				dic.Add("Delete", "D");

				string sqlMenuNum = $"SELECT MenuSubNum FROM MenuSub WHERE MenuSubUrl Like '/BackEnd/{controllerName}/%'";
				_basic.db_Connection();
				DataTable dtMenuNum = _basic.getDataTable(sqlMenuNum);
				string menuNum = dtMenuNum.Rows[0][0].ToString();

				string sqlRole = $"SELECT * FROM AdminRole WHERE GroupNum = {GroupNum} AND MenuSubNum = {menuNum} AND Role LIKE '%{dic[actionName].ToString()}%'";
				DataTable dtRole = _basic.getDataTable(sqlRole);

				_basic.db_Close();


				if(dtRole.Rows.Count == 0)
				{
					context.Result = new ContentResult()
					{
						Content = "<script>alert('權限不足');history.back()</script>",
						ContentType = "text/html;charset=utf-8",
					};

					return;
				}
			}
		}
	}
}
