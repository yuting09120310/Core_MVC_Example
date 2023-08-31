using Core_MVC_Example.BackEnd.Controllers;
using Microsoft.AspNetCore.Mvc;
using OBizCommonClass;

namespace Core_MVC_Example.Controllers
{
	public class HomeController : GenericController
    {

        public HomeController(Basic basic) : base(basic) { }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}