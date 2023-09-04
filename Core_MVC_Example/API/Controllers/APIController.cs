using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.Areas.BackEnd.Repository;
using Core_MVC_Example.BackEnd.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc;
using OBizCommonClass;

namespace Core_MVC_Example.API.Controllers
{
	public class APIController : Controller
    {

        private Basic _basic;


		public APIController(Basic basic) 
        {
            _basic = basic;
        }


        //新增資料(資料表名稱, 欄位名稱, 值)
        [HttpPost]
        [HttpGet]
        public ActionResult Insert(string tableName, string fields, string values)
        {
            try
            {
                string strSQL = $"INSERT INTO {tableName} ({fields})  VALUES ('{values}')";

                _basic.db_Connection();
                bool result = _basic.sqlExecute(strSQL);
                _basic.db_Close();

                return Content(result.ToString());
            }
            catch (Exception ex)
            {
                return Content("false");
            }
        }

        //修改資料(資料表名稱, 欄位名稱, 值, id)
        [HttpPost]
        [HttpGet]
        public ActionResult Update(string tableName, string fields, string values, int id)
        {
            try
            {
                string tableNum = tableName + "Num";
                string strSQL = $"UPDATE {tableName} SET {fields}='{values}' WHERE {tableNum} = {id}";

                _basic.db_Connection();
                bool result = _basic.sqlExecute(strSQL);
                _basic.db_Close();

                return Content(result.ToString());
            }
            catch (Exception ex)
            {
                return Content("false");
            }

        }

        //刪除資料(資料表名稱, id)
        [HttpPost]
        [HttpGet]
        public ActionResult Delete(string tableName, int id)
        {

            try
            {
                string tableNum = tableName + "Num";
                string strSQL = $"DELETE {tableName} WHERE {tableNum} = {id}";

                _basic.db_Connection();
                bool result = _basic.sqlExecute(strSQL);
                _basic.db_Close();

                return Content(result.ToString());
            }
            catch (Exception ex)
            {
                return Content("false");
            }
        }

    }
}
