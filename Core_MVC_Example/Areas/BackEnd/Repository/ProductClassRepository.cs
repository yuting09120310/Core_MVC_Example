using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.BackEnd.ViewModel.News;
using Core_MVC_Example.BackEnd.ViewModel.NewsClass;
using Core_MVC_Example.BackEnd.ViewModel.ProductClass;
using Microsoft.AspNetCore.Mvc.Rendering;
using NETCommonClass;
using System.Data;

namespace Core_MVC_Example.Areas.BackEnd.Repository
{
	public class ProductClassRepository : IProductClassRepository
    {
		private Basic _basic;


		public ProductClassRepository(Basic Basic)
		{
			_basic = Basic;
		}


		public List<ProductClassIndexViewModel> GetList()
		{
			string strSQL = @"SELECT ProductClassNum, ProductClassName, ProductClassPublish, CreateTime
                              FROM ProductClass";


			_basic.DB_Connection();
			DataTable dt = _basic.GetDataTable(strSQL);
			_basic.DB_Close();


			List<ProductClassIndexViewModel> indexViewModels = new List<ProductClassIndexViewModel>();
			foreach (DataRow item in dt.Rows)
			{
                ProductClassIndexViewModel indexViewModel = new ProductClassIndexViewModel()
				{
                    ProductClassNum = Convert.ToInt64(item.ItemArray[0]),
                    ProductClassName = item.ItemArray[1].ToString(),
                    ProductClassPublish = Convert.ToInt32(item.ItemArray[2]),
					CreateTime = Convert.ToDateTime(item.ItemArray[3]),
				};
				indexViewModels.Add(indexViewModel);
			}

			return indexViewModels;
		}


        public ProductClassCreateViewModel Create()
        {
            ProductClassCreateViewModel viewModel = new ProductClassCreateViewModel();

			return viewModel;
        }


        public void Create(ProductClassCreateViewModel createViewModel, string AdminNum)
		{
			string strSQL = " INSERT INTO ProductClass (ProductClassName, ProductClassPublish, CreateTime, Creator) VALUES " +
							$" ('{createViewModel.ProductClassName}','{createViewModel.ProductClassPublish}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{AdminNum}')";


			_basic.DB_Connection();

			_basic.SqlExecute(strSQL);

			_basic.DB_Close();
		}


		public ProductClassEditViewModel Edit(long id)
		{
			_basic.DB_Connection();

			string strSQL = $"SELECT TOP 1 ProductClassNum, ProductClassName, ProductClassPublish FROM ProductClass Where ProductClassNum = {id}";
			DataTable dt = _basic.GetDataTable(strSQL);

            ProductClassEditViewModel editViewModel = new ProductClassEditViewModel()
			{
				ProductClassNum = Convert.ToInt32(dt.Rows[0]["ProductClassNum"].ToString()),
				ProductClassName = dt.Rows[0]["ProductClassName"].ToString(),
				ProductClassPublish = Convert.ToInt32(dt.Rows[0]["ProductClassPublish"].ToString())
			};

			_basic.DB_Close();

			return editViewModel;
		}


		public void Edit(ProductClassEditViewModel editViewModel, string AdminNum)
		{
			string strSQL = "UPDATE ProductClass ";
			strSQL += $"SET ProductClassName = '{editViewModel.ProductClassName}', ";
			strSQL += $"ProductClassPublish = '{editViewModel.ProductClassPublish}', ";
			strSQL += $"EditTime = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', ";
			strSQL += $"Editor = '{AdminNum}' ";
			strSQL += $"WHERE ProductClassNum = {editViewModel.ProductClassNum}";

			_basic.DB_Connection();

			_basic.SqlExecute(strSQL);

			_basic.DB_Close();
		}


		public void Delete(int id)
		{
			_basic.DB_Connection();

			string strSQL = $"DELETE FROM ProductClass WHERE ProductClassNum = {id}";
			_basic.SqlExecute(strSQL);

			_basic.DB_Close();
		}
	}
}
