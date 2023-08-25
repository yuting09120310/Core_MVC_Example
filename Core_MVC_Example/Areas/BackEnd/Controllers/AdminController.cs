using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using OBizCommonClass;
using Core_MVC_Example.BackEnd.ViewModel.Admin;
using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.Areas.BackEnd.Repository;
using System.Collections.Generic;
using Core_MVC_Example.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_MVC_Example.BackEnd.Controllers
{
	public class AdminController : GenericController
    {
        private IAdminRepository<Admin> _adminRepository;
        CoreMvcExampleContext _context;

		public AdminController(Basic basic, CoreMvcExampleContext context) : base(basic, context) 
        {
			_context = context;
			_adminRepository = new AdminRepository<Admin>(_context);
        }


        public ActionResult Index()
        {
            List<AdminIndexViewModel> indexViewModels = _adminRepository.GetList();
			
			return View(indexViewModels);
        }


        public ActionResult Create()
        {
            GetGroup();

			return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdminCreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
				string strSQL = @$"INSERT INTO Admin ( GroupNum, AdminAcc, AdminName, AdminPwd, AdminPublish) 
                                    VALUES ('{createViewModel.GroupNum}' , '{createViewModel.AdminAcc}' ,'{createViewModel.AdminName}' , 
                                    '{createViewModel.AdminPwd}' , '{createViewModel.AdminPublish}' )";

				_basic.db_Connection();
				_basic.sqlExecute(strSQL);
				_basic.db_Close();

				return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createViewModel);
            }
        }


        public ActionResult Edit(int id)
        {
            GetGroup();

            _basic.db_Connection();

            string strSQL = $"SELECT TOP 1 *  FROM Admin WHERE AdminNum = {id}";
			DataTable dt = _basic.getDataTable(strSQL);

			AdminEditViewModel editViewModel = new AdminEditViewModel()
            {
				AdminNum = Convert.ToInt32(dt.Rows[0]["AdminNum"].ToString()),
				AdminAcc = dt.Rows[0]["AdminAcc"].ToString(),
				AdminName = dt.Rows[0]["AdminName"].ToString(),
			};

			_basic.db_Close();

			return View(editViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdminEditViewModel editViewModel)
        {
            try
            {
                string strSQL = @$"UPDATE Admin
                                SET AdminAcc = '{editViewModel.AdminAcc}', AdminName = '{editViewModel.AdminName}', AdminPwd = '{editViewModel.AdminPwd}'
                                WHERE AdminNum = '{editViewModel.AdminNum}'";

                _basic.db_Connection();
                _basic.sqlExecute(strSQL);
                _basic.db_Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
			string strSQL = $"DELETE FROM Admin WHERE AdminNum = {id}";

            _basic.db_Connection();
            _basic.sqlExecute(strSQL);
            _basic.db_Close();

            return Json("刪除完成");
        }


        public void GetGroup()
        {
            string strSQL = "SELECT GroupNum,GroupName FROM admingroup WHERE GroupPublish = 1";
            _basic.db_Connection();
            DataTable dt = _basic.getDataTable(strSQL);
            _basic.db_Close();

            List<SelectListItem> adminGroup = new List<SelectListItem>();
            foreach (DataRow item in dt.Rows)
            {
                adminGroup.Add(new SelectListItem { Text = item.ItemArray[1].ToString(), Value = item.ItemArray[0].ToString() });
            }

            ViewBag.adminGroup = adminGroup;
        }
    }
}
