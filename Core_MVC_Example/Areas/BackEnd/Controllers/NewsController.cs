﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using OBizCommonClass;
using Core_MVC_Example.BackEnd.ViewModel.AdminGroup;
using Core_MVC_Example.BackEnd.ViewModel.News;
using Microsoft.AspNetCore.Authorization;
using Core_MVC_Example.Areas.BackEnd.Attribute;
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
			ViewBag.adminGroup = _newsRepository.GetGroup();

			return View();
        }


        [HttpPost]
        public ActionResult Create(NewsCreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
				var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "News");

				_newsRepository.SaveFile(createViewModel.NewsImg, direPath);

				createViewModel.Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));

				_newsRepository.Create(createViewModel);

				return RedirectToAction(nameof(Index));
            }
            else
            {
				ViewBag.adminGroup = _newsRepository.GetGroup();
				return View(createViewModel);
            }
        }


        public ActionResult Edit(int id)
        {
			ViewBag.adminGroup = _newsRepository.GetGroup();

			string path = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "News");

            NewsEditViewModel editViewModel = _newsRepository.Edit(id, path);

			return View(editViewModel);
        }


        [HttpPost]
        public ActionResult Edit(NewsEditViewModel editViewModel)
		{
            if(ModelState.IsValid)
            {
				var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "News");
				if (editViewModel.NewsImg != null)
				{
					_newsRepository.SaveFile(editViewModel.NewsImg, direPath);
				}

				editViewModel.Editor = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));

				_newsRepository.Edit(editViewModel);

				return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(editViewModel);
            }
			
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


        
    }
}
