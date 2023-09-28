using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.Areas.BackEnd.Repository;
using Core_MVC_Example.BackEnd.ViewModel.News;
using Core_MVC_Example.BackEnd.ViewModel.Product;
using Microsoft.AspNetCore.Mvc;
using NETCommonClass;
using System.Data;

namespace Core_MVC_Example.BackEnd.Controllers
{
	public class ProductController : GenericController
    {
		private IProductRepository _productRepository;

		private readonly IWebHostEnvironment _hostingEnvironment;

		public ProductController(Basic basic, IWebHostEnvironment hostingEnvironment) : base(basic) 
		{ 
			_hostingEnvironment = hostingEnvironment;
			_productRepository = new ProductRepository(basic);
		}


        public ActionResult Index()
        {
			List<ProductIndexViewModel> indexViewModels = _productRepository.GetList();

			return View(indexViewModels);
        }


        public ActionResult Create()
        {
            ViewBag.adminGroup = _productRepository.GetGroup();

            ProductCreateViewModel createViewModel = _productRepository.Create();

			return View(createViewModel);
        }


        [HttpPost]
        public ActionResult Create(ProductCreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
				var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "Product");

                _productRepository.SaveFile(createViewModel.ProductImg1, direPath);

				createViewModel.Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));

                _productRepository.Create(createViewModel);

				return RedirectToAction(nameof(Index));
            }
            else
            {
				ViewBag.adminGroup = _productRepository.GetGroup();
				return View(createViewModel);
            }
        }


        public ActionResult Edit(int id)
        {
			ViewBag.adminGroup = _productRepository.GetGroup();

			string path = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "Product");

			ProductEditViewModel editViewModel = _productRepository.Edit(id, path);

			return View(editViewModel);
        }


        [HttpPost]
        public ActionResult Edit(ProductEditViewModel editViewModel)
		{
            if(ModelState.IsValid)
            {
				var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "Product");
				if (editViewModel.ProductImg != null)
				{
                    _productRepository.DelFile(editViewModel.ProductNum, direPath);
                    _productRepository.SaveFile(editViewModel.ProductImg, direPath);
				}

				editViewModel.Editor = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));

                _productRepository.Edit(editViewModel);

				return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(editViewModel);
            }
			
		}


        public ActionResult Delete(int id)
        {
            _productRepository.Delete(id);

            return Json("刪除完成");
        }
    }
}
