using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.Areas.BackEnd.Repository;
using Core_MVC_Example.BackEnd.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc;
using OBizCommonClass;

namespace Core_MVC_Example.BackEnd.Controllers
{
	public class AdminController : GenericController
    {

        private IAdminRepository _adminRepository;


		public AdminController(Basic basic) : base(basic) 
        {
			_adminRepository = new AdminRepository(basic);
        }


        public ActionResult Index()
        {
            List<AdminIndexViewModel> indexViewModels = _adminRepository.GetList();
			
			return View(indexViewModels);
        }


        public ActionResult Create()
        {
            ViewBag.adminGroup = _adminRepository.GetGroup();

			return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdminCreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                createViewModel.Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));

				_adminRepository.Create(createViewModel);

				return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createViewModel);
            }
        }


        public ActionResult Edit(int id)
        {
            ViewBag.adminGroup = _adminRepository.GetGroup();

			AdminEditViewModel editViewModel = _adminRepository.Edit(id);

			return View(editViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdminEditViewModel editViewModel)
        {
            try
            {
				editViewModel.Editor = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));
				_adminRepository.Edit(editViewModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
			_adminRepository.Delete(id);
            return Json("刪除完成");
        }

    }
}
