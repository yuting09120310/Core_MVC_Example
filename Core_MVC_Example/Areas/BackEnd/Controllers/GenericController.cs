using Core_MVC_Example.Areas.BackEnd.Attribute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OBizCommonClass;
using System.Data;

namespace Core_MVC_Example.BackEnd.Controllers
{
	[Auth]
	[Area("BackEnd")]
    public class GenericController : Controller
    {

        public Basic _basic;


        public GenericController(Basic basic)
        {
            _basic = basic;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            GetMenu();
        }


        public void GetMenu()
        {
            _basic.db_Connection();

            int GroupNum = Convert.ToInt16(HttpContext.Session.GetString("GroupNum"));

            string module = @"SELECT *
                              FROM MenuGroup
                              WHERE MenuGroupPublish = 1
                              ORDER BY MenuGroupNum ASC";

            DataTable moduleDt = _basic.getDataTable(module);
            ViewBag.module = moduleDt;


            string moduleFun = @$"SELECT c.*
                                 FROM MenuSub c
                                 JOIN AdminRole s ON c.MenuSubNum = s.MenuSubNum
                                 WHERE c.MenuSubPublish = 1 AND s.GroupNum = {GroupNum}
                                 ";

            DataTable moduleFunDt = _basic.getDataTable(moduleFun);
            ViewBag.moduleFun = moduleFunDt;

            _basic.db_Close();


            ViewBag.AdminName = HttpContext.Session.GetString("AdminName");
            ViewBag.AdminNum = HttpContext.Session.GetString("AdminNum");
        }
    }
}
