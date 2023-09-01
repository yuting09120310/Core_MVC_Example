using Core_MVC_Example.Areas.BackEnd.Interface;
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


		public NewsEditViewModel Edit(long id, string path)
		{
			_basic.db_Connection();

			string strSQL = $"SELECT TOP 1 NewsNum, NewsClass, NewsTitle, NewsImg1, NewsDescription, NewsContxt, NewsSort, NewsPutTime, NewsOffTime, NewsPublish, Editor, EditTime FROM News Where NewsNum = {id}";
			DataTable dt = _basic.getDataTable(strSQL);

			// 從資料庫中獲取檔案路徑
			string filepath = Path.Combine(path, dt.Rows[0]["NewsImg1"].ToString());

			// 讀取檔案數據
			byte[] fileData = System.IO.File.ReadAllBytes(filepath);

			// 創建 FormFile 物件
			IFormFile formFile = new FormFile(new MemoryStream(fileData), 0, fileData.Length, "NewsImg", Path.GetFileName(filepath));


			NewsEditViewModel editViewModel = new NewsEditViewModel()
			{
				NewsNum = Convert.ToInt64(dt.Rows[0]["NewsNum"].ToString()),
				NewsClassNum = Convert.ToInt32(dt.Rows[0]["NewsClass"].ToString()),
				NewsTitle = dt.Rows[0]["NewsTitle"].ToString(),
				NewsImg = formFile,
				NewsDescription = dt.Rows[0]["NewsDescription"].ToString(),
				NewsContent = dt.Rows[0]["NewsContxt"].ToString(),
				Sort = int.TryParse(dt.Rows[0]["NewsSort"].ToString(), out var parseNum) ? parseNum : 0,
				NewsPutTime = DateTime.TryParse(dt.Rows[0]["NewsPutTime"].ToString(), out DateTime result) ? result : DateTime.Now,
				NewsOffTime = DateTime.TryParse(dt.Rows[0]["NewsOffTime"].ToString(), out DateTime results) ? results : DateTime.Now,
				NewsPublish = Convert.ToInt32(dt.Rows[0]["NewsPublish"].ToString())
			};


			_basic.db_Close();

			return editViewModel;
		}


		public void Edit(NewsEditViewModel editViewModel)
		{
			string strSQL = "UPDATE News ";
			strSQL += $"SET NewsClass = '{editViewModel.NewsClassNum}', ";
			strSQL += $"NewsTitle = '{editViewModel.NewsTitle}', ";
			strSQL += $"NewsDescription = '{editViewModel.NewsDescription}', ";
			strSQL += $"NewsContxt = '{editViewModel.NewsContent}', ";

			if (editViewModel.NewsImg != null)
			{
				strSQL += $"NewsImg1 = '{editViewModel.NewsImg.FileName}', ";
			}
			
			strSQL += $"NewsPublish = '{editViewModel.NewsPublish}', ";
			strSQL += $"NewsPutTime = '{Convert.ToDateTime(editViewModel.NewsPutTime).ToString("yyyy-MM-dd HH:mm:ss")}', ";
			strSQL += $"NewsOffTime = '{Convert.ToDateTime(editViewModel.NewsOffTime).ToString("yyyy-MM-dd HH:mm:ss")}', ";
			strSQL += $"EditTime = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', ";
			strSQL += $"Editor = '{editViewModel.Editor}' ";
			strSQL += $"WHERE NewsNum = {editViewModel.NewsNum}";

			_basic.db_Connection();

			_basic.sqlExecute(strSQL);

			_basic.db_Close();
		}


		public void Delete(int id)
		{
			_basic.db_Connection();

			string strSQL = $"DELETE FROM News WHERE NewsNum = {id}";
			_basic.sqlExecute(strSQL);

			strSQL = $"DELETE FROM News WHERE NewsNum = {id}";
			_basic.sqlExecute(strSQL);

			_basic.db_Close();
		}


		public List<SelectListItem> GetGroup()
		{
			string strSQL = "SELECT NewsClassNum,NewsClassName FROM NewsClass WHERE NewsClassPublish = 1";
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

		public void DelFile(long id, string path)
		{
			string strSQL = $"SELECT NewsImg1 From News WHERE NewsNum = '{id}'";
			_basic.db_Connection();
			DataTable dt =  _basic.getDataTable(strSQL);
			_basic.db_Close();

			if(dt.Rows.Count > 0)
			{
				string fileName = dt.Rows[0][0].ToString();
				string filePath = Path.Combine(path, fileName);
				
				if (File.Exists(filePath))
				{
					System.IO.File.Delete(filePath);
				}
			}
		}
	}
}
