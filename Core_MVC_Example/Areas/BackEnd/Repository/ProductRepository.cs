using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.BackEnd.ViewModel.Product;
using Core_MVC_Example.BackEnd.ViewModel.Product;
using Microsoft.AspNetCore.Mvc.Rendering;
using NETCommonClass;
using System.Data;

namespace Core_MVC_Example.Areas.BackEnd.Repository
{
	public class ProductRepository : IProductRepository
	{
		private Basic _basic;


		public ProductRepository(Basic Basic)
		{
			_basic = Basic;
		}


		public List<ProductIndexViewModel> GetList()
		{
			string strSQL = @"SELECT ProductNum, ProductTitle, ProductPublish, n.CreateTime, n.EditTime , ns.ProductClassName
                              FROM Product as n
                              LEFT JOIN ProductClass as ns
                              ON n.ProductClass = ns.ProductClassNum";


			_basic.DB_Connection();
			DataTable dt = _basic.GetDataTable(strSQL);
			_basic.DB_Close();


			List<ProductIndexViewModel> indexViewModels = new List<ProductIndexViewModel>();
			foreach (DataRow item in dt.Rows)
			{
				ProductIndexViewModel indexViewModel = new ProductIndexViewModel()
				{
					ProductNum = Convert.ToInt64(item.ItemArray[0]),
					ProductTitle = item.ItemArray[1].ToString(),
					ProductPublish = Convert.ToInt32(item.ItemArray[2]),
					CreateTime = Convert.ToDateTime(item.ItemArray[3]),
					EditTime = DateTime.TryParse(item.ItemArray[4].ToString(), out var parsedTime) ? parsedTime : (DateTime?)null,
					ProductClassName = item.ItemArray[5].ToString(),
				};
				indexViewModels.Add(indexViewModel);
			}

			return indexViewModels;
		}


        public ProductCreateViewModel Create()
		{
			ProductCreateViewModel productCreateViewModel = new ProductCreateViewModel();
			return productCreateViewModel;
        }


        public void Create(ProductCreateViewModel createViewModel)
		{
			string strSQL = " INSERT INTO Product (ProductClass, ProductTitle, ProductDescription, ProductContxt, ProductImg1, ProductPublish, ProductPutTime, ProductOffTime, CreateTime, Creator) VALUES " +
							$" ('{createViewModel.ProductClassNum}', '{createViewModel.ProductTitle}', '{createViewModel.ProductDescription}', '{createViewModel.ProductContent}', '{createViewModel.ProductImg1.FileName}', '{createViewModel.ProductPublish}', '{Convert.ToDateTime(createViewModel.ProductPutTime).ToString("yyyy-MM-dd HH:mm:ss")}', '{Convert.ToDateTime(createViewModel.ProductOffTime).ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{createViewModel.Creator}')";

			_basic.DB_Connection();

			_basic.SqlExecute(strSQL);

			_basic.DB_Close();
		}


		public ProductEditViewModel Edit(long id, string path)
		{
			_basic.DB_Connection();

			string strSQL = $"SELECT TOP 1 ProductNum, ProductClass, ProductTitle, ProductImg1, ProductDescription, ProductContxt, ProductSort, ProductPutTime, ProductOffTime, ProductPublish, Editor, EditTime FROM Product Where ProductNum = {id}";
			DataTable dt = _basic.GetDataTable(strSQL);

			// 從資料庫中獲取檔案路徑
			string filepath = Path.Combine(path, dt.Rows[0]["ProductImg1"].ToString());

			// 讀取檔案數據
			byte[] fileData = System.IO.File.ReadAllBytes(filepath);

			// 創建 FormFile 物件
			IFormFile formFile = new FormFile(new MemoryStream(fileData), 0, fileData.Length, "ProductImg", Path.GetFileName(filepath));


			ProductEditViewModel editViewModel = new ProductEditViewModel()
			{
				ProductNum = Convert.ToInt64(dt.Rows[0]["ProductNum"].ToString()),
				ProductClassNum = Convert.ToInt32(dt.Rows[0]["ProductClass"].ToString()),
				ProductTitle = dt.Rows[0]["ProductTitle"].ToString(),
				ProductImg = formFile,
				ProductDescription = dt.Rows[0]["ProductDescription"].ToString(),
				ProductContent = dt.Rows[0]["ProductContxt"].ToString(),
				Sort = int.TryParse(dt.Rows[0]["ProductSort"].ToString(), out var parseNum) ? parseNum : 0,
				ProductPutTime = DateTime.TryParse(dt.Rows[0]["ProductPutTime"].ToString(), out DateTime result) ? result : DateTime.Now,
				ProductOffTime = DateTime.TryParse(dt.Rows[0]["ProductOffTime"].ToString(), out DateTime results) ? results : DateTime.Now,
				ProductPublish = Convert.ToInt32(dt.Rows[0]["ProductPublish"].ToString())
			};


			_basic.DB_Close();

			return editViewModel;
		}


		public void Edit(ProductEditViewModel editViewModel)
		{
			string strSQL = "UPDATE Product ";
			strSQL += $"SET ProductClass = '{editViewModel.ProductClassNum}', ";
			strSQL += $"ProductTitle = '{editViewModel.ProductTitle}', ";
			strSQL += $"ProductDescription = '{editViewModel.ProductDescription}', ";
			strSQL += $"ProductContxt = '{editViewModel.ProductContent}', ";

			if (editViewModel.ProductImg != null)
			{
				strSQL += $"ProductImg1 = '{editViewModel.ProductImg.FileName}', ";
			}
			
			strSQL += $"ProductPublish = '{editViewModel.ProductPublish}', ";
			strSQL += $"ProductPutTime = '{Convert.ToDateTime(editViewModel.ProductPutTime).ToString("yyyy-MM-dd HH:mm:ss")}', ";
			strSQL += $"ProductOffTime = '{Convert.ToDateTime(editViewModel.ProductOffTime).ToString("yyyy-MM-dd HH:mm:ss")}', ";
			strSQL += $"EditTime = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', ";
			strSQL += $"Editor = '{editViewModel.Editor}' ";
			strSQL += $"WHERE ProductNum = {editViewModel.ProductNum}";

			_basic.DB_Connection();

			_basic.SqlExecute(strSQL);

			_basic.DB_Close();
		}


		public void Delete(int id)
		{
			_basic.DB_Connection();

			string strSQL = $"DELETE FROM Product WHERE ProductNum = {id}";
			_basic.SqlExecute(strSQL);

			strSQL = $"DELETE FROM Product WHERE ProductNum = {id}";
			_basic.SqlExecute(strSQL);

			_basic.DB_Close();
		}


		public List<SelectListItem> GetGroup()
		{
			string strSQL = "SELECT ProductClassNum,ProductClassName FROM ProductClass WHERE ProductClassPublish = 1";
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
			string strSQL = $"SELECT ProductImg1 From Product WHERE ProductNum = '{id}'";
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
