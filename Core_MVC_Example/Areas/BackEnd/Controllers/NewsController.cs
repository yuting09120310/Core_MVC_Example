using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using OBizCommonClass;
using Core_MVC_Example.BackEnd.ViewModel.AdminGroup;
using Core_MVC_Example.BackEnd.ViewModel.News;
using Microsoft.AspNetCore.Authorization;
using Core_MVC_Example.Areas.BackEnd.Filter;
using Core_MVC_Example.Models;
using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.Areas.BackEnd.Repository;

namespace Core_MVC_Example.BackEnd.Controllers
{
    
	public class NewsController : GenericController
    {
		private INewsRepository _newsRepository;

		private readonly IWebHostEnvironment _hostingEnvironment;

		public NewsController(Basic basic, IWebHostEnvironment hostingEnvironment) : base(basic) 
		{ 
			_hostingEnvironment = hostingEnvironment;
			_newsRepository = new NewsRepository(basic);
		}


        public ActionResult Index()
        {
			List<NewsIndexViewModel> indexViewModels = _newsRepository.GetList();

			return View(indexViewModels);
        }


        public ActionResult Create()
        {
            GetGroup();

            return View();
        }


        [HttpPost]
        public ActionResult Create(NewsCreateViewModel createViewModel)
        {
			var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "News");

			_newsRepository.SaveFile(createViewModel.NewsImg, direPath);

			createViewModel.Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));

			_newsRepository.Create(createViewModel);

            return RedirectToAction(nameof(Index));
        }


        public ActionResult Edit(int id)
        {
            GetGroup();

            _basic.db_Connection();

            string strSQL = $"SELECT TOP 1 NewsNum, NewsClass, NewsTitle, NewsImg1, NewsDescription, NewsContxt, NewsSort, NewsPutTime, NewsOffTime, NewsPublish, Editor, EditTime FROM News Where NewsNum = {id}";
            DataTable dt = _basic.getDataTable(strSQL);



			// 從資料庫中獲取檔案路徑
			string filePathFromDatabase = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "News", dt.Rows[0]["NewsImg1"].ToString());

			// 讀取檔案數據
			byte[] fileData = System.IO.File.ReadAllBytes(filePathFromDatabase);

			// 創建 FormFile 物件
			IFormFile formFile = new FormFile(new MemoryStream(fileData), 0, fileData.Length, "NewsImg", Path.GetFileName(filePathFromDatabase));


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

            return View(editViewModel);
        }


        [HttpPost]
        public ActionResult Edit(NewsEditViewModel editViewModel)
		{
			var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "News");
			if (!Directory.Exists(direPath))
			{
				Directory.CreateDirectory(direPath);
			}

			var filePath = Path.Combine(direPath, editViewModel.NewsImg.FileName);
			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				editViewModel.NewsImg.CopyTo(fileStream);
			}


			editViewModel.Editor = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));

			string strSQL = "UPDATE News " +
				$"SET NewsClass = '{editViewModel.NewsClassNum}', " +
				$"NewsTitle = '{editViewModel.NewsTitle}', " +
				$"NewsDescription = '{editViewModel.NewsDescription}', " +
				$"NewsContxt = '{editViewModel.NewsContent}', " +
				$"NewsImg1 = '{editViewModel.NewsImg.FileName}', " +
				$"NewsPublish = '{editViewModel.NewsPublish}', " +
				$"NewsPutTime = '{Convert.ToDateTime(editViewModel.NewsPutTime).ToString("yyyy-MM-dd HH:mm:ss")}', " +
				$"NewsOffTime = '{Convert.ToDateTime(editViewModel.NewsOffTime).ToString("yyyy-MM-dd HH:mm:ss")}', " +
				$"EditTime = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', " +
				$"Editor = '{editViewModel.Editor}' " +
				$"WHERE NewsNum = {editViewModel.NewsNum}";

			_basic.db_Connection();

			_basic.sqlExecute(strSQL);

			_basic.db_Close();

			return RedirectToAction(nameof(Index));
		}


        public ActionResult Delete(int id)
        {
            _basic.db_Connection();

            string strSQL = $"DELETE FROM News WHERE NewsNum = {id}";
            _basic.sqlExecute(strSQL);

            strSQL = $"DELETE FROM News WHERE NewsNum = {id}";
            _basic.sqlExecute(strSQL);

            _basic.db_Close();

            return Json("刪除完成");
        }


        public void GetGroup()
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

            ViewBag.adminGroup = adminGroup;
        }
    }
}
