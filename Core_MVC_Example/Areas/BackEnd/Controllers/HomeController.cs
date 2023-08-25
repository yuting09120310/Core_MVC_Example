using Core_MVC_Example.BackEnd.Controllers;
using Core_MVC_Example.Models;
using Microsoft.AspNetCore.Mvc;
using OBizCommonClass;
using System.Diagnostics;

namespace Core_MVC_Example.Controllers
{
    public class HomeController : GenericController
    {

        public HomeController(Basic basic, CoreMvcExampleContext context) : base(basic, context) { }


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
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            return View();
        }
    }
}