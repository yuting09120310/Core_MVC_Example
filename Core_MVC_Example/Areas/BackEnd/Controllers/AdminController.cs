using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using OBizCommonClass;
using Core_MVC_Example.BackEnd.ViewModel.Admin;

namespace Core_MVC_Example.BackEnd.Controllers
{
	public class AdminController : GenericController
    {

        public AdminController(Basic basic) : base(basic) { }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.Result = !CheckLoginState() ? new RedirectToActionResult("Index", "Login", null) : null;
            GetMenu();
        }


        public ActionResult Index()
        {
            string strSQL = @$"SELECT a.AdminNum, g.GroupName, a.AdminAcc, a.AdminName, a.AdminPublish
                            FROM Admin a
                            LEFT JOIN AdminGroup g ON a.GroupNum = g.GroupNum";


            _basic.db_Connection();
            DataTable dt = _basic.getDataTable(strSQL);
            _basic.db_Close();


            List<AdminIndexViewModel> indexViewModels = new List<AdminIndexViewModel>();
            foreach(DataRow item in dt.Rows)
            {
                AdminIndexViewModel indexViewModel = new AdminIndexViewModel()
                {
                    AdminNum = Convert.ToInt64(item.ItemArray[0]),
					GroupName = item.ItemArray[1].ToString(),
                    AdminAcc = item.ItemArray[2].ToString(),
                    AdminName = item.ItemArray[3].ToString(),
                    AdminPublish = Convert.ToInt32(item.ItemArray[4]),
                };
                indexViewModels.Add(indexViewModel);
            }


            return View(indexViewModels);
        }


        public ActionResult Create()
        {
			_basic.db_Connection();

			#region 取得群組下拉選單
			string strSQL = "SELECT GroupNum,GroupName FROM admingroup WHERE GroupPublish = 1";
			DataTable dt = _basic.getDataTable(strSQL);

			List<SelectListItem> adminGroup = new List<SelectListItem>();
			foreach (DataRow item in dt.Rows)
			{
				adminGroup.Add(new SelectListItem { Text = item.ItemArray[1].ToString(), Value = item.ItemArray[0].ToString() });
			}

            ViewBag.adminGroup = adminGroup;
			#endregion

			_basic.db_Close();

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
			_basic.db_Connection();

			#region 取得群組下拉選單
			string strSQL = "SELECT GroupNum,GroupName FROM admingroup WHERE GroupPublish = 1";
			_basic.db_Connection();
			DataTable dt = _basic.getDataTable(strSQL);

			List<SelectListItem> adminGroup = new List<SelectListItem>();
			foreach (DataRow item in dt.Rows)
			{
				adminGroup.Add(new SelectListItem { Text = item.ItemArray[1].ToString(), Value = item.ItemArray[0].ToString() });
			}

			ViewBag.adminGroup = adminGroup;
			#endregion

			strSQL = $"SELECT TOP 1 *  FROM Admin WHERE AdminNum = {id}";
			dt = _basic.getDataTable(strSQL);

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

    }
}
