using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.Areas.BackEnd.Repository;
using Core_MVC_Example.BackEnd.ViewModel.Banner;
using Microsoft.AspNetCore.Mvc;
using NETCommonClass;
using System.Data;

namespace Core_MVC_Example.BackEnd.Controllers
{
	public class BannerController : GenericController
    {
		private IBannerRepository _BannerRepository;

		private readonly IWebHostEnvironment _hostingEnvironment;

		public BannerController(Basic basic, IWebHostEnvironment hostingEnvironment) : base(basic) 
		{ 
			_hostingEnvironment = hostingEnvironment;
			_BannerRepository = new BannerRepository(basic);
		}


        public ActionResult Index()
        {
			List<BannerIndexViewModel> indexViewModels = _BannerRepository.GetList();

			return View(indexViewModels);
        }


        public ActionResult Create()
        {
			return View();
        }


        [HttpPost]
        public ActionResult Create(BannerCreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
				var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "Banner");

				_BannerRepository.SaveFile(createViewModel.BannerImg, direPath);

				createViewModel.Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));

				_BannerRepository.Create(createViewModel);

				return RedirectToAction(nameof(Index));
            }
            else
            {
				return View(createViewModel);
            }
        }


        public ActionResult Edit(int id)
        {
			string path = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "Banner");

            BannerEditViewModel editViewModel = _BannerRepository.Edit(id, path);

			return View(editViewModel);
        }


        [HttpPost]
        public ActionResult Edit(BannerEditViewModel editViewModel)
		{
            if(ModelState.IsValid)
            {
				var direPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "Banner");
				if (editViewModel.BannerImg != null)
				{
                    _BannerRepository.DelFile(editViewModel.BannerNum, direPath);
					_BannerRepository.SaveFile(editViewModel.BannerImg, direPath);
				}

				editViewModel.Editor = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));

				_BannerRepository.Edit(editViewModel);

				return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(editViewModel);
            }
			
		}


        public ActionResult Delete(int id)
        {
            _BannerRepository.Delete(id);

            return Json("刪除完成");
        }


        
    }
}
