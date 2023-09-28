using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.BackEnd.ViewModel.Member;
using Microsoft.AspNetCore.Mvc.Rendering;
using NETCommonClass;
using System.Data;

namespace Core_MVC_Example.Areas.BackEnd.Repository
{
	public class MemberRepository : IMemberRepository
	{
		private Basic _basic;


		public MemberRepository(Basic Basic)
		{
			_basic = Basic;
		}


		public List<MemberIndexViewModel> GetList()
		{
			string strSQL = @"SELECT MemberNum, MemberAccount, MemberName, MemberPhone, MemberEmail, CreateTime
                              FROM Member ";


			_basic.DB_Connection();
			DataTable dt = _basic.GetDataTable(strSQL);
			_basic.DB_Close();


			List<MemberIndexViewModel> indexViewModels = new List<MemberIndexViewModel>();
			foreach (DataRow item in dt.Rows)
			{
				MemberIndexViewModel indexViewModel = new MemberIndexViewModel()
				{
					MemberNum = Convert.ToInt64(item.ItemArray[0]),
					MemberAccount = item.ItemArray[1].ToString(),
					MemberName = item.ItemArray[2].ToString(),
					MemberPhone = item.ItemArray[3].ToString(),
					MemberEmail = item.ItemArray[4].ToString(),
					CreateTime = Convert.ToDateTime(item.ItemArray[5]),
				};
				indexViewModels.Add(indexViewModel);
			}

			return indexViewModels;
		}
		

		public void Create(MemberCreateViewModel createViewModel)
		{
			string strSQL = " INSERT INTO Member (MemberAccount, MemberPassword, MemberName, MemberPhone, MemberEmail, MemberPublish, CreateTime, Creator) VALUES " +
							$" ('{createViewModel.MemberAccount}', '{createViewModel.MemberPassword}', '{createViewModel.MemberName}', '{createViewModel.MemberPhone}', '{createViewModel.MemberEmail}', '{createViewModel.MemberPublish}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{createViewModel.Creator}')";

			_basic.DB_Connection();

			_basic.SqlExecute(strSQL);

			_basic.DB_Close();
		}


		public MemberEditViewModel Edit(long id)
		{
			_basic.DB_Connection();

			string strSQL = $"SELECT TOP 1 MemberNum, MemberTitle, MemberImg1, MemberDescription, MemberSort, MemberPutTime, MemberOffTime, MemberPublish, Editor, EditTime FROM Member Where MemberNum = {id}";
			DataTable dt = _basic.GetDataTable(strSQL);
			
			MemberEditViewModel editViewModel = new MemberEditViewModel()
			{
				MemberNum = Convert.ToInt64(dt.Rows[0]["MemberNum"].ToString()),
				MemberAccount = dt.Rows[0]["MemberTitle"].ToString(),
				MemberPassword = dt.Rows[0]["MemberPassword"].ToString(),
				MemberName = dt.Rows[0]["MemberName"].ToString(),
				MemberPhone = dt.Rows[0]["MemberPhone"].ToString(),
				MemberEmail = dt.Rows[0]["MemberEmail"].ToString(),
				MemberPublish = Convert.ToInt32(dt.Rows[0]["MemberPublish"].ToString())
			};


			_basic.DB_Close();

			return editViewModel;
		}


		public void Edit(MemberEditViewModel editViewModel)
		{
			string strSQL = "UPDATE Member ";
			strSQL += $"MemberAccount = '{editViewModel.MemberAccount}', ";
			strSQL += $"MemberPassword = '{editViewModel.MemberPassword}', ";
			strSQL += $"MemberName = '{editViewModel.MemberName}', ";
			strSQL += $"MemberPhone = '{editViewModel.MemberPhone}', ";
			strSQL += $"MemberEmail = '{editViewModel.MemberEmail}', ";
			strSQL += $"MemberPublish = '{editViewModel.MemberPublish}', ";
			strSQL += $"EditTime = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', ";
			strSQL += $"Editor = '{editViewModel.Editor}' ";
			strSQL += $"WHERE MemberNum = {editViewModel.MemberNum}";

			_basic.DB_Connection();

			_basic.SqlExecute(strSQL);

			_basic.DB_Close();
		}


		public void Delete(int id)
		{
			_basic.DB_Connection();

			string strSQL = $"DELETE FROM Member WHERE MemberNum = {id}";
			_basic.SqlExecute(strSQL);

			strSQL = $"DELETE FROM Member WHERE MemberNum = {id}";
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
			string strSQL = $"SELECT MemberImg1 From Member WHERE MemberNum = '{id}'";
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
