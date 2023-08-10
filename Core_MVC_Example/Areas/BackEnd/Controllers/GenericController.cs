﻿using Microsoft.AspNetCore.Mvc;
using OBizCommonClass;
using System.Data;

namespace Core_MVC_Example.BackEnd.Controllers
{
    [Area("BackEnd")]
    public class GenericController : Controller
    {

        public Basic _basic;


        public GenericController(Basic basic)
        {
            _basic = basic;
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


        public bool CheckLoginState()
        {
            string GroupNum = HttpContext.Session.GetString("GroupNum");
            string AdminName = HttpContext.Session.GetString("AdminName");
            string AdminNum = HttpContext.Session.GetString("AdminNum");

            if(string.IsNullOrEmpty(GroupNum) || string.IsNullOrEmpty(AdminName) || string.IsNullOrEmpty(AdminNum))
            {
                TempData["ErrorMessage"] = "尚未登入或登入逾期，請重新登入。";
                return false;
            }
            
            return true;
        }
    }
}
