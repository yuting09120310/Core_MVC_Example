using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.BackEnd.ViewModel.News;
using Core_MVC_Example.BackEnd.ViewModel.NewsClass;
using Microsoft.AspNetCore.Mvc.Rendering;
using OBizCommonClass;
using System.Data;

namespace Core_MVC_Example.Areas.BackEnd.Repository
{
	public class NewsClassRepository : INewsClassRepository
	{
		private Basic _basic;


		public NewsClassRepository(Basic Basic)
		{
			_basic = Basic;
		}


		public List<NewsClassIndexViewModel> GetList()
		{
			string strSQL = @"SELECT NewsClassNum, NewsClassName, NewsClassPublish, CreateTime
                              FROM NewsClass";


			_basic.db_Connection();
			DataTable dt = _basic.getDataTable(strSQL);
			_basic.db_Close();


			List<NewsClassIndexViewModel> indexViewModels = new List<NewsClassIndexViewModel>();
			foreach (DataRow item in dt.Rows)
			{
                NewsClassIndexViewModel indexViewModel = new NewsClassIndexViewModel()
				{
                    NewsClassNum = Convert.ToInt64(item.ItemArray[0]),
                    NewsClassName = item.ItemArray[1].ToString(),
                    NewsClassPublish = Convert.ToInt32(item.ItemArray[2]),
					CreateTime = Convert.ToDateTime(item.ItemArray[3]),
				};
				indexViewModels.Add(indexViewModel);
			}

			return indexViewModels;
		}


        public NewsClassCreateViewModel Create()
        {
            NewsClassCreateViewModel viewModel = new NewsClassCreateViewModel();

			return viewModel;
        }



        public void Create(NewsClassCreateViewModel createViewModel, string AdminNum)
		{
			string strSQL = " INSERT INTO NewsClass (NewsClassName, NewsClassPublish, CreateTime, Creator) VALUES " +
							$" ('{createViewModel.NewsClassName}','{createViewModel.NewsClassPublish}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{AdminNum}')";

			_basic.db_Connection();

			_basic.sqlExecute(strSQL);

			_basic.db_Close();
		}


		public NewsClassEditViewModel Edit(long id)
		{
			_basic.db_Connection();

			string strSQL = $"SELECT TOP 1 NewsClassNum, NewsClassName, NewsClassPublish FROM NewsClass Where NewsClassNum = {id}";
			DataTable dt = _basic.getDataTable(strSQL);

			NewsClassEditViewModel editViewModel = new NewsClassEditViewModel()
			{
				NewsClassNum = Convert.ToInt32(dt.Rows[0]["NewsClassNum"].ToString()),
				NewsClassName = dt.Rows[0]["NewsClassName"].ToString(),
				NewsClassPublish = Convert.ToInt32(dt.Rows[0]["NewsClassPublish"].ToString())
			};

			_basic.db_Close();

			return editViewModel;
		}


		public void Edit(NewsClassEditViewModel editViewModel, string AdminNum)
		{
			string strSQL = "UPDATE NewsClass ";
			strSQL += $"SET NewsClassName = '{editViewModel.NewsClassName}', ";
			strSQL += $"NewsClassPublish = '{editViewModel.NewsClassPublish}', ";
			strSQL += $"EditTime = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', ";
			strSQL += $"Editor = '{AdminNum}' ";
			strSQL += $"WHERE NewsClassNum = {editViewModel.NewsClassNum}";

			_basic.db_Connection();

			_basic.sqlExecute(strSQL);

			_basic.db_Close();
		}


		public void Delete(int id)
		{
			_basic.db_Connection();

			string strSQL = $"DELETE FROM NewsClass WHERE NewsClassNum = {id}";
			_basic.sqlExecute(strSQL);

			_basic.db_Close();
		}
	}
}
