﻿using Microsoft.AspNetCore.Mvc;
using NETCommonClass;

namespace Core_MVC_Example.BackEnd.Controllers
{

	public class LogoutController : GenericController {


		public LogoutController(Basic basic) : base(basic) { }


		public IActionResult Index() {

            HttpContext.Session.Remove("AdminNum");
            HttpContext.Session.Remove("AdminName");
            HttpContext.Session.Remove("GroupNum");

            return RedirectToAction("Index", "Login");
        }

    }
}
