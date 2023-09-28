using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.Areas.BackEnd.Repository;
using Core_MVC_Example.BackEnd.ViewModel.Member;
using Microsoft.AspNetCore.Mvc;
using NETCommonClass;
using System.Data;

namespace Core_MVC_Example.BackEnd.Controllers
{
	public class MemberController : GenericController
    {
		private IMemberRepository _MemberRepository;

		private readonly IWebHostEnvironment _hostingEnvironment;

		public MemberController(Basic basic, IWebHostEnvironment hostingEnvironment) : base(basic) 
		{ 
			_hostingEnvironment = hostingEnvironment;
			_MemberRepository = new MemberRepository(basic);
		}


        public ActionResult Index()
        {
			List<MemberIndexViewModel> indexViewModels = _MemberRepository.GetList();

			return View(indexViewModels);
        }


        public ActionResult Create()
        {
			return View();
        }


        [HttpPost]
        public ActionResult Create(MemberCreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
				createViewModel.Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));

				_MemberRepository.Create(createViewModel);

				return RedirectToAction(nameof(Index));
            }
            else
            {
				return View(createViewModel);
            }
        }


        public ActionResult Edit(int id)
        {
            MemberEditViewModel editViewModel = _MemberRepository.Edit(id);

			return View(editViewModel);
        }


        [HttpPost]
        public ActionResult Edit(MemberEditViewModel editViewModel)
		{
            if(ModelState.IsValid)
            {
				editViewModel.Editor = Convert.ToInt32(HttpContext.Session.GetString("AdminNum"));

				_MemberRepository.Edit(editViewModel);

				return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(editViewModel);
            }
			
		}


        public ActionResult Delete(int id)
        {
            _MemberRepository.Delete(id);

            return Json("刪除完成");
        }


        
    }
}
