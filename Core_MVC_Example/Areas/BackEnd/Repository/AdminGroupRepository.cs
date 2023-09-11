using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.BackEnd.ViewModel.AdminGroup;
using OBizCommonClass;
using System.Data;

namespace Core_MVC_Example.Areas.BackEnd.Repository
{
	public class AdminGroupRepository : IAdminGroupRepository
	{
		private Basic _basic;


		public AdminGroupRepository(Basic Basic)
		{
			_basic = Basic;
		}


		public List<AdminGroupIndexViewModel> GetList()
		{
			string strSQL = "SELECT GroupNum, GroupName, GroupPublish, CreateTime FROM AdminGroup WHERE GroupPublish = 1";


			_basic.db_Connection();
			DataTable dt = _basic.getDataTable(strSQL);
			_basic.db_Close();


			List<AdminGroupIndexViewModel> indexViewModels = new List<AdminGroupIndexViewModel>();
			foreach (DataRow item in dt.Rows)
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

			return indexViewModels;
		}
		

		public AdminGroupCreateViewModel Create()
		{
			_basic.db_Connection();

			string sqlMenuGroup = "SELECT MenuGroupId, MenuGroupName, MenuGroupIcon FROM MenuGroup";
			string sqlMenuSub = "SELECT MenuSubNum,MenuGroupId, MenuSubId, MenuSubName FROM MenuSub";

			AdminGroupCreateViewModel createViewModel = new AdminGroupCreateViewModel()
			{
				GroupName = "",
				GroupInfo = "",
				GroupPublish = 1,

				MenuGroupModels = _basic.getDataTable(sqlMenuGroup),
				MenuSubModels = _basic.getDataTable(sqlMenuSub),
				AdminRoleModels = new DataTable(),
			};


			_basic.db_Close();

			return createViewModel;
		}


		public void Create(IFormCollection Collection, string AdminNun)
		{
			_basic.db_Connection();

			string strSQL = $"INSERT INTO AdminGroup (GroupName, GroupInfo, GroupPublish, CreateTime, Creator) VALUES ('{Collection["GroupName"].ToString()}', '{Collection["GroupInfo"].ToString()}', '1', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', {AdminNun}) ; SELECT SCOPE_IDENTITY();";
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
		}


		public AdminGroupEditViewModel Edit(int id)
		{
			AdminGroupEditViewModel editViewModel = new AdminGroupEditViewModel();
			return editViewModel;
		}


		public void Edit(long id, IFormCollection Collection)
		{
			Dictionary<string, string> roleDicts = Collection
				 .Where(kv => kv.Key.StartsWith("e"))
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
		}


		public void Delete(int id)
		{
			_basic.db_Connection();

			string strSQL = $"DELETE FROM AdminGroup WHERE GroupNum = {id}";
			_basic.sqlExecute(strSQL);

			strSQL = $"DELETE FROM AdminRole WHERE GroupNum = {id}";
			_basic.sqlExecute(strSQL);

			_basic.db_Close();
		}


		public void Dispose()
		{

		}
	}
}
