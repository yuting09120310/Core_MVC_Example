using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.BackEnd.ViewModel.Admin;
using Core_MVC_Example.Models;
using OBizCommonClass;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Core_MVC_Example.Areas.BackEnd.Repository
{
	public class AdminRepository<T> : IAdminRepository<T>, ITest<T> where T : Admin
	{
		private CoreMvcExampleContext _context;

		public AdminRepository(CoreMvcExampleContext context)
		{
			_context = context;
		}

		public List<T> List()
		{
			AdminIndexViewModel viewModel = new AdminIndexViewModel()
			{
				

			};





			string strSQL = @$"SELECT a.AdminNum, g.GroupName, a.AdminAcc, a.AdminName, a.AdminPublish
                            FROM Admin a
                            LEFT JOIN AdminGroup g ON a.GroupNum = g.GroupNum
			";


			//_basic.db_Connection();
			//DataTable dt = _basic.getDataTable(strSQL);
			//_basic.db_Close();

			DataTable dt = new DataTable();


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

			return new List<T>();
		}

		public void Create(T model)
		{
			_context.Admins.Add(model);
			_context.SaveChanges();
		}

		public void Delete(List<int> id)
		{

		}

		public void Delete(int id)
		{

		}

		public void Dispose()
		{
		}

		public List<AdminIndexViewModel> GetList()
		{
			List<AdminIndexViewModel> query = (from admin in _context.Admins
													  join adGroup in _context.AdminGroups on admin.GroupNum equals adGroup.GroupNum
													  select new AdminIndexViewModel()
													  {
														  AdminNum = admin.AdminNum,
														  GroupName = adGroup.GroupName,
														  AdminAcc = admin.AdminAcc,
														  AdminName = admin.AdminName,
														  AdminPublish = admin.AdminPublish,
													  }).ToList();


			return query;
		}
	}
}
