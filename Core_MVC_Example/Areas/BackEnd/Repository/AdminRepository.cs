using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.BackEnd.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc.Rendering;
using NETCommonClass;
using System.Data;

namespace Core_MVC_Example.Areas.BackEnd.Repository
{
	public class AdminRepository : IAdminRepository
	{
		private Basic _basic;


		public AdminRepository(Basic Basic)
		{
			_basic = Basic;
		}


		public List<AdminIndexViewModel> GetList()
		{
			string strSQL = @$"SELECT a.AdminNum, g.GroupName, a.AdminAcc, a.AdminName, a.AdminPublish
                            FROM Admin a
                            LEFT JOIN AdminGroup g ON a.GroupNum = g.GroupNum
			";


			_basic.DB_Connection();
			DataTable dt = _basic.GetDataTable(strSQL);
			_basic.DB_Close();

			List<AdminIndexViewModel> indexViewModels = new List<AdminIndexViewModel>();
			foreach (DataRow item in dt.Rows)
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

			return indexViewModels;
		}
		

		public void Create(AdminCreateViewModel createViewModel)
		{
			string strSQL = @$"INSERT INTO Admin ( GroupNum, AdminAcc, AdminName, AdminPwd, AdminPublish,    Creator) 
                                    VALUES ('{createViewModel.GroupNum}' , '{createViewModel.AdminAcc}' ,'{createViewModel.AdminName}' , 
                                    '{createViewModel.AdminPwd}' , '{createViewModel.AdminPublish}', '{createViewModel.Creator}' )";

			_basic.DB_Connection();
			_basic.SqlExecute(strSQL);
			_basic.DB_Close();
		}


		public AdminEditViewModel Edit(int id)
		{
			_basic.DB_Connection();

			string strSQL = $"SELECT TOP 1 *  FROM Admin WHERE AdminNum = {id}";
			DataTable dt = _basic.GetDataTable(strSQL);

			AdminEditViewModel editViewModel = new AdminEditViewModel()
			{
				AdminNum = Convert.ToInt32(dt.Rows[0]["AdminNum"].ToString()),
				AdminAcc = dt.Rows[0]["AdminAcc"].ToString(),
				AdminName = dt.Rows[0]["AdminName"].ToString(),
			};

			_basic.DB_Close();

			return editViewModel;
		}


		public void Edit(AdminEditViewModel editViewModel)
		{
			string strSQL = @$"UPDATE Admin
                                SET AdminAcc = '{editViewModel.AdminAcc}', AdminName = '{editViewModel.AdminName}', AdminPwd = '{editViewModel.AdminPwd}' , Editor = '{editViewModel.Editor}'
                                WHERE AdminNum = '{editViewModel.AdminNum}'";

			_basic.DB_Connection();
			_basic.SqlExecute(strSQL);
			_basic.DB_Close();
		}


		public void Delete(int id)
		{
			string strSQL = $"DELETE FROM Admin WHERE AdminNum = {id}";

			_basic.DB_Connection();
			_basic.SqlExecute(strSQL);
			_basic.DB_Close();
		}


		public List<SelectListItem> GetGroup()
		{
			string strSQL = "SELECT GroupNum,GroupName FROM admingroup WHERE GroupPublish = 1";
			_basic.DB_Connection();
			DataTable dt = _basic.GetDataTable(strSQL);
			_basic.DB_Close();

			List<SelectListItem> adminGroup = new List<SelectListItem>();
			foreach (DataRow item in dt.Rows)
			{
				adminGroup.Add(new SelectListItem { Text = item.ItemArray[1].ToString(), Value = item.ItemArray[0].ToString() });
			}

			return adminGroup;
		}


		public void Dispose()
		{

		}


		//public List<AdminIndexViewModel> GetList()
		//{
		//	List<AdminIndexViewModel> query = (from admin in _context.Admins
		//											  join adGroup in _context.AdminGroups on admin.GroupNum equals adGroup.GroupNum
		//											  select new AdminIndexViewModel()
		//											  {
		//												  AdminNum = admin.AdminNum,
		//												  GroupName = adGroup.GroupName,
		//												  AdminAcc = admin.AdminAcc,
		//												  AdminName = admin.AdminName,
		//												  AdminPublish = admin.AdminPublish,
		//											  }).ToList();


		//	return query;
		//}
	}
}
