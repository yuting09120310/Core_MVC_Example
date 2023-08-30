using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.BackEnd.ViewModel.Admin;
using Core_MVC_Example.BackEnd.ViewModel.News;
using Microsoft.AspNetCore.Mvc.Rendering;
using OBizCommonClass;
using System.Data;

namespace Core_MVC_Example.Areas.BackEnd.Repository
{
	public class NewsRepository : INewsRepository
	{
		private Basic _basic;


		public NewsRepository(Basic Basic)
		{
			_basic = Basic;
		}


		public List<NewsIndexViewModel> GetList()
		{
			string strSQL = @"SELECT NewsNum, NewsTitle, NewsPublish, n.CreateTime, n.EditTime , ns.NewsClassName
                              FROM News as n
                              LEFT JOIN NewsClass as ns
                              ON n.NewsClass = ns.NewsClassNum";


			_basic.db_Connection();
			DataTable dt = _basic.getDataTable(strSQL);
			_basic.db_Close();


			List<NewsIndexViewModel> indexViewModels = new List<NewsIndexViewModel>();
			foreach (DataRow item in dt.Rows)
			{
				NewsIndexViewModel indexViewModel = new NewsIndexViewModel()
				{
					NewsNum = Convert.ToInt64(item.ItemArray[0]),
					NewsTitle = item.ItemArray[1].ToString(),
					NewsPublish = Convert.ToInt32(item.ItemArray[2]),
					CreateTime = Convert.ToDateTime(item.ItemArray[3]),
					EditTime = DateTime.TryParse(item.ItemArray[4].ToString(), out var parsedTime) ? parsedTime : (DateTime?)null,
					NewsClassName = item.ItemArray[5].ToString(),
				};
				indexViewModels.Add(indexViewModel);
			}

			return indexViewModels;
		}
		

		public void Create(NewsCreateViewModel createViewModel)
		{
			string strSQL = " INSERT INTO News (NewsClass, NewsTitle, NewsDescription, NewsContxt, NewsImg1, NewsPublish, NewsPutTime, NewsOffTime, CreateTime, Creator) VALUES " +
							$" ('{createViewModel.NewsClassNum}', '{createViewModel.NewsTitle}', '{createViewModel.NewsDescription}', '{createViewModel.NewsContent}', '{createViewModel.NewsImg.FileName}', '{createViewModel.NewsPublish}', '{Convert.ToDateTime(createViewModel.NewsPutTime).ToString("yyyy-MM-dd HH:mm:ss")}', '{Convert.ToDateTime(createViewModel.NewsOffTime).ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{createViewModel.Creator}')";

			_basic.db_Connection();

			_basic.sqlExecute(strSQL);

			_basic.db_Close();
		}


		public NewsEditViewModel Edit(int id)
		{
			NewsEditViewModel editViewModel = new NewsEditViewModel();

			return editViewModel;
		}


		public void Edit(NewsEditViewModel editViewModel)
		{
			
		}


		public void Delete(int id)
		{
			
		}


		public List<SelectListItem> GetGroup()
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

			return adminGroup;
		}


		public void Dispose()
		{

		}

		public void SaveFile(IFormFile file, string savePath)
		{
			if (!Directory.Exists(savePath))
			{
				Directory.CreateDirectory(savePath);
			}

			var filePath = Path.Combine(savePath, file.FileName);
			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				file.CopyTo(fileStream);
			}
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
