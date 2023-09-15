using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.Areas.BackEnd.Repository;
using Core_MVC_Example.BackEnd.ViewModel.News;
using Core_MVC_Example.BackEnd.ViewModel.NewsClass;
using Core_MVC_Example.BackEnd.ViewModel.ProductClass;
using Microsoft.AspNetCore.Mvc;
using OBizCommonClass;
using System.Data;

namespace Core_MVC_Example.BackEnd.Controllers
{
	public class ProductClassController : GenericController
    {
        private IProductClassRepository _productClassRepository;

		private readonly IWebHostEnvironment _hostingEnvironment;

		public ProductClassController(Basic basic, IWebHostEnvironment hostingEnvironment) : base(basic) 
		{ 
			_hostingEnvironment = hostingEnvironment;
            _productClassRepository = new ProductClassRepository(basic);
		}


        public ActionResult Index()
        {
			List<ProductClassIndexViewModel> indexViewModels = _productClassRepository.GetList();

			return View(indexViewModels);
        }


        public ActionResult Create()
        {
            ProductClassCreateViewModel viewModel = _productClassRepository.Create();

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Create(ProductClassCreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                _productClassRepository.Create(createViewModel, HttpContext.Session.GetString("AdminNum"));

				return RedirectToAction(nameof(Index));
            }
            else
            {
				return View(createViewModel);
            }
        }


        public ActionResult Edit(int id)
        {
            ProductClassEditViewModel editViewModel = _productClassRepository.Edit(id);

			return View(editViewModel);
        }


        [HttpPost]
        public ActionResult Edit(ProductClassEditViewModel editViewModel)
		{
            if(ModelState.IsValid)
            {
                _productClassRepository.Edit(editViewModel, HttpContext.Session.GetString("AdminNum"));

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(editViewModel);
            }
			
		}


        public ActionResult Delete(int id)
        {
            _productClassRepository.Delete(id);

            return Json("刪除完成");
        }


        
    }
}
