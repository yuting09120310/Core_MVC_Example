using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NETCommonClass;
using System.Data;

namespace Core_MVC_Example.API.Controllers
{
    public class APIController : Controller
    {

        private Basic _basic;


		public APIController(Basic basic) 
        {
            _basic = basic;
        }


        //搜尋全部(資料表名稱)
        [HttpPost]
        [HttpGet]
        public ActionResult SelectAll(string tableName)
        {
            try
            {
                string strSQL = $"SELECT * FROM {tableName}";

                _basic.DB_Connection();
                DataTable result = _basic.GetDataTable(strSQL);
                _basic.DB_Close();

                string res = JsonConvert.SerializeObject(result);

                return Content(res);
            }
            catch (Exception ex)
            {
                return Content("false");
            }
        }


        //搜尋(資料表名稱, 欄位名稱, 值)
        [HttpPost]
        [HttpGet]
        public ActionResult Select(string tableName, string fields, string values)
        {
            try
            {
                string strSQL = $"SELECT * FROM {tableName} WHERE {fields} = '{values}'";

                _basic.DB_Connection();
                DataTable result = _basic.GetDataTable(strSQL);
                _basic.DB_Close();

                string res = JsonConvert.SerializeObject(result);

                return Content(res);
            }
            catch (Exception ex)
            {
                return Content("false");
            }
        }


        //新增資料(資料表名稱, 欄位名稱, 值)
        [HttpPost]
        [HttpGet]
        public ActionResult Insert(string tableName, string fields, string values)
        {
            try
            {
                string strSQL = $"INSERT INTO {tableName} ({fields})  VALUES ('{values}')";

                _basic.DB_Connection();
                bool result = _basic.SqlExecute(strSQL);
                _basic.DB_Close();

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

                _basic.DB_Connection();
                bool result = _basic.SqlExecute(strSQL);
                _basic.DB_Close();

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

                _basic.DB_Connection();
                bool result = _basic.SqlExecute(strSQL);
                _basic.DB_Close();

                return Content(result.ToString());
            }
            catch (Exception ex)
            {
                return Content("false");
            }
        }

    }
}
