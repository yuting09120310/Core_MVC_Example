using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.Areas.BackEnd.Repository;
using Core_MVC_Example.BackEnd.ViewModel.News;
using Core_MVC_Example.BackEnd.ViewModel.NewsClass;
using Microsoft.AspNetCore.Mvc;
using NETCommonClass;
using System.Data;

namespace Core_MVC_Example.BackEnd.Controllers
{
	public class NewsClassController : GenericController
    {
        private INewsClassRepository _newsClassRepository;

		private readonly IWebHostEnvironment _hostingEnvironment;

		public NewsClassController(Basic basic, IWebHostEnvironment hostingEnvironment) : base(basic) 
		{ 
			_hostingEnvironment = hostingEnvironment;
            _newsClassRepository = new NewsClassRepository(basic);
		}


        public ActionResult Index()
        {
			List<NewsClassIndexViewModel> indexViewModels = _newsClassRepository.GetList();

			return View(indexViewModels);
        }


        public ActionResult Create()
        {
            NewsClassCreateViewModel viewModel = _newsClassRepository.Create();

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Create(NewsClassCreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                _newsClassRepository.Create(createViewModel, HttpContext.Session.GetString("AdminNum"));

				return RedirectToAction(nameof(Index));
            }
            else
            {
				return View(createViewModel);
            }
        }


        public ActionResult Edit(int id)
        {
            NewsClassEditViewModel editViewModel = _newsClassRepository.Edit(id);

			return View(editViewModel);
        }


        [HttpPost]
        public ActionResult Edit(NewsClassEditViewModel editViewModel)
		{
            if(ModelState.IsValid)
            {
                _newsClassRepository.Edit(editViewModel, HttpContext.Session.GetString("AdminNum"));

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(editViewModel);
            }
			
		}


        public ActionResult Delete(int id)
        {
            _newsClassRepository.Delete(id);

            return Json("刪除完成");
        }


        
    }
}
