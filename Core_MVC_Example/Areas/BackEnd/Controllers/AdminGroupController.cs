using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using OBizCommonClass;
using Core_MVC_Example.BackEnd.ViewModel.Admin;
using Core_MVC_Example.BackEnd.ViewModel.AdminGroup;

namespace Core_MVC_Example.BackEnd.Controllers
{
	public class AdminGroupController : GenericController
    {

        public AdminGroupController(Basic basic) : base(basic) { }


        public ActionResult Index()
        {
            string strSQL = "SELECT GroupNum, GroupName, GroupPublish, CreateTime FROM AdminGroup WHERE GroupPublish = 1";


            _basic.db_Connection();
            DataTable dt = _basic.getDataTable(strSQL);
            _basic.db_Close();


            List<AdminGroupIndexViewModel> indexViewModels = new List<AdminGroupIndexViewModel>();
            foreach(DataRow item in dt.Rows)
            {
                AdminGroupIndexViewModel indexViewModel = new AdminGroupIndexViewModel()
                {
                    GroupNum = Convert.ToInt64(item.ItemArray[0]),
					GroupName = item.ItemArray[1].ToString(),
                    AdminPublish = Convert.ToInt32(item.ItemArray[2]),
                    CreateTime = Convert.ToDateTime(item.ItemArray[3]),
                };
                indexViewModels.Add(indexViewModel);
            }

            return View(indexViewModels);
        }


        public ActionResult Create()
        {
            _basic.db_Connection();

            string sqlMenuGroup = "SELECT MenuGroupId, MenuGroupName, MenuGroupIcon FROM MenuGroup";
            string sqlMenuSub = "SELECT MenuSubNum,MenuGroupId, MenuSubId, MenuSubName FROM MenuSub";

            AdminGroupCreateViewModel createViewModel = new AdminGroupCreateViewModel()
            {
                CreatorName = HttpContext.Session.GetString("AdminName")!,
                Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum")),
                GroupName = "",
                GroupInfo = "", 
                GroupPublish = 1,

                MenuGroupModels = _basic.getDataTable(sqlMenuGroup),
                MenuSubModels = _basic.getDataTable(sqlMenuSub),
                AdminRoleModels = new DataTable(),
            };


            _basic.db_Close();

            return View(createViewModel);
        }


        [HttpPost]
        public ActionResult Create(IFormCollection Collection)
        {
            _basic.db_Connection();

            string strSQL = $"INSERT INTO AdminGroup (GroupName, GroupInfo, GroupPublish, CreateTime, Creator) VALUES ('{Collection["GroupName"].ToString()}', '{Collection["GroupInfo"].ToString()}', '1', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '1') ; SELECT SCOPE_IDENTITY();";
            DataTable dt = _basic.getDataTable(strSQL);

            int groupNum = Convert.ToInt32(dt.Rows[0][0].ToString());

            Dictionary<string, string> roleDicts = Collection
                 .Where(kv => kv.Key.StartsWith("e"))
                 .Select(kv => new KeyValuePair<string, string>(kv.Key.Split('_')[1], kv.Value!))
                 .ToDictionary(kv => kv.Key, kv => kv.Value);

            foreach (string roleDict in roleDicts.Keys)
            {
                strSQL = $"INSERT INTO AdminRole (GroupNum, MenuSubNum, Role, CreateTime, Creator) VALUES ('{groupNum}', '{roleDict}', '{roleDicts[roleDict].ToString()}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '1')";
                _basic.sqlExecute(strSQL);
            }

            _basic.db_Close();

            return RedirectToAction(nameof(Index));
        }


        public ActionResult Edit(int id)
        {
            _basic.db_Connection();

            string sqlMenuGroup = "SELECT MenuGroupId, MenuGroupName, MenuGroupIcon FROM MenuGroup";
            string sqlMenuSub = "SELECT MenuSubNum,MenuGroupId, MenuSubId, MenuSubName FROM MenuSub";
            string sqlRole = $"SELECT RoleNum, GroupNum, MenuSubNum, Role FROM AdminRole WHERE GroupNum = {id}";


            string sqlGroup = $"SELECT GroupName, GroupInfo FROM AdminGroup WHERE GroupNum = {id}";
            DataTable dtGroup = _basic.getDataTable(sqlGroup);

            AdminGroupCreateViewModel createViewModel = new AdminGroupCreateViewModel()
            {
                CreatorName = HttpContext.Session.GetString("AdminName")!,
                Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum")),
                GroupName = dtGroup.Rows[0]["GroupName"].ToString(),
                GroupInfo = dtGroup.Rows[0]["GroupInfo"].ToString(),
                GroupPublish = 1,

                MenuGroupModels = _basic.getDataTable(sqlMenuGroup),
                MenuSubModels = _basic.getDataTable(sqlMenuSub),
                AdminRoleModels = _basic.getDataTable(sqlRole),
            };


            _basic.db_Close();

            return View(createViewModel);
        }


        [HttpPost]
        public ActionResult Edit(long id, IFormCollection Collection)
        {
            try
            {
                Dictionary<string, string> roleDicts = Collection
                 .Where(kv => kv.Key.StartsWith("Role"))
                 .Select(kv => new KeyValuePair<string, string>(kv.Key.Split('_')[1], kv.Value!))
                 .ToDictionary(kv => kv.Key, kv => kv.Value);

                int groupNum = Convert.ToInt32(id);

                _basic.db_Connection();


                foreach (string roleDict in roleDicts.Keys)
                {
                    long menuSubNum = Convert.ToInt64(roleDict);
                    string strRole = $"SELECT * FROM AdminRole WHERE GroupNum = '{groupNum}' AND MenuSubNum = '{menuSubNum}'";

                    DataTable dataTable = _basic.getDataTable(strRole);

                    
                    string strSQL = string.Empty;

                    if (dataTable.Rows.Count > 0)
                    {
                        strSQL = $"UPDATE AdminRole SET Role = '{roleDicts[roleDict].ToString()}' WHERE GroupNum = '{groupNum}' AND MenuSubNum = '{menuSubNum}'";
                    }
                    else
                    {
                        strSQL = $"INSERT INTO AdminRole (GroupNum, MenuSubNum, Role, CreateTime, Creator) VALUES ('{groupNum}', '{menuSubNum}', '{roleDicts[roleDict].ToString()}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '1')";
                    }

                    _basic.sqlExecute(strSQL);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            _basic.db_Connection();

            string strSQL = $"DELETE FROM AdminGroup WHERE GroupNum = {id}";
            _basic.sqlExecute(strSQL);

            strSQL = $"DELETE FROM AdminRole WHERE GroupNum = {id}";
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
