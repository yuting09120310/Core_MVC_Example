using Core_MVC_Example.Models;
using Microsoft.AspNetCore.Mvc;
using OBizCommonClass;
using System.Data;

namespace Core_MVC_Example.BackEnd.Controllers
{

    public class LogoutController : GenericController {

		public LogoutController(Basic basic) : base(basic) { }

		// 登入頁面
		public IActionResult Index() {

            HttpContext.Session.Remove("AdminNum");
            HttpContext.Session.Remove("AdminName");
            HttpContext.Session.Remove("GroupNum");

            return RedirectToAction("Index", "Login");
        }

    }
}
