using Microsoft.AspNetCore.Mvc;
using OBizCommonClass;
using System.Data;

namespace Core_MVC_Example.BackEnd.Controllers
{
	[Area("BackEnd")]
    public class LoginController : Controller 
    {

        public Basic _basic;

        public LoginController(Basic basic)
        {
            _basic = basic;
        }


        public IActionResult Index() {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string accountNumber, string accountPassword) 
        {
            _basic.db_Connection();
            DataTable dt =  _basic.getDataTable($"SELECT TOP 1 * FROM Admin WHERE AdminAcc = '{accountNumber}' AND AdminPwd = '{_basic.md5(accountPassword)}'");
            _basic.db_Close();


            if(dt.Rows.Count > 0)
            {
                HttpContext.Session.SetString("AdminNum", dt.Rows[0]["AdminNum"].ToString()!);
                HttpContext.Session.SetString("AdminName", dt.Rows[0]["AdminName"].ToString()!);
                HttpContext.Session.SetString("GroupNum", dt.Rows[0]["GroupNum"].ToString()!);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "登入失敗，請檢察帳號密碼是否輸入錯誤";
                return View();
            }
        }
    }
}
