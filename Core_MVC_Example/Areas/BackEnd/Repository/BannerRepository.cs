using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.BackEnd.ViewModel.Banner;
using Microsoft.AspNetCore.Mvc.Rendering;
using NETCommonClass;
using System.Data;

namespace Core_MVC_Example.Areas.BackEnd.Repository
{
	public class BannerRepository : IBannerRepository
	{
		private Basic _basic;


		public BannerRepository(Basic Basic)
		{
			_basic = Basic;
		}


		public List<BannerIndexViewModel> GetList()
		{
			string strSQL = @"SELECT BannerNum, BannerTitle, BannerPublish, CreateTime, EditTime
                              FROM Banner ";


			_basic.DB_Connection();
			DataTable dt = _basic.GetDataTable(strSQL);
			_basic.DB_Close();


			List<BannerIndexViewModel> indexViewModels = new List<BannerIndexViewModel>();
			foreach (DataRow item in dt.Rows)
			{
				BannerIndexViewModel indexViewModel = new BannerIndexViewModel()
				{
					BannerNum = Convert.ToInt64(item.ItemArray[0]),
					BannerTitle = item.ItemArray[1].ToString(),
					BannerPublish = Convert.ToInt32(item.ItemArray[2]),
					CreateTime = Convert.ToDateTime(item.ItemArray[3]),
					EditTime = DateTime.TryParse(item.ItemArray[4].ToString(), out var parsedTime) ? parsedTime : (DateTime?)null,
				};
				indexViewModels.Add(indexViewModel);
			}

			return indexViewModels;
		}
		

		public void Create(BannerCreateViewModel createViewModel)
		{
			string strSQL = " INSERT INTO Banner (BannerTitle, BannerDescription, BannerImg1, BannerPublish, BannerPutTime, BannerOffTime, CreateTime, Creator) VALUES " +
							$" ('{createViewModel.BannerTitle}', '{createViewModel.BannerDescription}', '{createViewModel.BannerImg.FileName}', '{createViewModel.BannerPublish}', '{Convert.ToDateTime(createViewModel.BannerPutTime).ToString("yyyy-MM-dd HH:mm:ss")}', '{Convert.ToDateTime(createViewModel.BannerOffTime).ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{createViewModel.Creator}')";

			_basic.DB_Connection();

			_basic.SqlExecute(strSQL);

			_basic.DB_Close();
		}


		public BannerEditViewModel Edit(long id, string path)
		{
			_basic.DB_Connection();

			string strSQL = $"SELECT TOP 1 BannerNum, BannerTitle, BannerImg1, BannerDescription, BannerSort, BannerPutTime, BannerOffTime, BannerPublish, Editor, EditTime FROM Banner Where BannerNum = {id}";
			DataTable dt = _basic.GetDataTable(strSQL);

			// 從資料庫中獲取檔案路徑
			string filepath = Path.Combine(path, dt.Rows[0]["BannerImg1"].ToString());

			// 讀取檔案數據
			byte[] fileData = System.IO.File.ReadAllBytes(filepath);

			// 創建 FormFile 物件
			IFormFile formFile = new FormFile(new MemoryStream(fileData), 0, fileData.Length, "BannerImg", Path.GetFileName(filepath));


			BannerEditViewModel editViewModel = new BannerEditViewModel()
			{
				BannerNum = Convert.ToInt64(dt.Rows[0]["BannerNum"].ToString()),
				BannerTitle = dt.Rows[0]["BannerTitle"].ToString(),
				BannerImg = formFile,
				BannerDescription = dt.Rows[0]["BannerDescription"].ToString(),
				Sort = int.TryParse(dt.Rows[0]["BannerSort"].ToString(), out var parseNum) ? parseNum : 0,
				BannerPutTime = DateTime.TryParse(dt.Rows[0]["BannerPutTime"].ToString(), out DateTime result) ? result : DateTime.Now,
				BannerOffTime = DateTime.TryParse(dt.Rows[0]["BannerOffTime"].ToString(), out DateTime results) ? results : DateTime.Now,
				BannerPublish = Convert.ToInt32(dt.Rows[0]["BannerPublish"].ToString())
			};


			_basic.DB_Close();

			return editViewModel;
		}


		public void Edit(BannerEditViewModel editViewModel)
		{
			string strSQL = "UPDATE Banner ";
			strSQL += $"BannerTitle = '{editViewModel.BannerTitle}', ";
			strSQL += $"BannerDescription = '{editViewModel.BannerDescription}', ";

			if (editViewModel.BannerImg != null)
			{
				strSQL += $"BannerImg1 = '{editViewModel.BannerImg.FileName}', ";
			}
			
			strSQL += $"BannerPublish = '{editViewModel.BannerPublish}', ";
			strSQL += $"BannerPutTime = '{Convert.ToDateTime(editViewModel.BannerPutTime).ToString("yyyy-MM-dd HH:mm:ss")}', ";
			strSQL += $"BannerOffTime = '{Convert.ToDateTime(editViewModel.BannerOffTime).ToString("yyyy-MM-dd HH:mm:ss")}', ";
			strSQL += $"EditTime = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', ";
			strSQL += $"Editor = '{editViewModel.Editor}' ";
			strSQL += $"WHERE BannerNum = {editViewModel.BannerNum}";

			_basic.DB_Connection();

			_basic.SqlExecute(strSQL);

			_basic.DB_Close();
		}


		public void Delete(int id)
		{
			_basic.DB_Connection();

			string strSQL = $"DELETE FROM Banner WHERE BannerNum = {id}";
			_basic.SqlExecute(strSQL);

			strSQL = $"DELETE FROM Banner WHERE BannerNum = {id}";
			_basic.SqlExecute(strSQL);

			_basic.DB_Close();
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
			string strSQL = $"SELECT BannerImg1 From Banner WHERE BannerNum = '{id}'";
			_basic.DB_Connection();
			DataTable dt =  _basic.GetDataTable(strSQL);
			_basic.DB_Close();

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
