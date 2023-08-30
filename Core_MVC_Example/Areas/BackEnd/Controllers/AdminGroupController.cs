using Core_MVC_Example.Areas.BackEnd.Interface;
using Core_MVC_Example.Areas.BackEnd.Repository;
using Core_MVC_Example.BackEnd.ViewModel.AdminGroup;
using Microsoft.AspNetCore.Mvc;
using OBizCommonClass;
using System.Data;

namespace Core_MVC_Example.BackEnd.Controllers
{
	public class AdminGroupController : GenericController
    {

		private IAdminGroupRepository _adminGroupRepository;


		public AdminGroupController(Basic basic) : base(basic) {
			_adminGroupRepository = new AdminGroupRepository(basic);
		}


        public ActionResult Index()
        {
            List<AdminGroupIndexViewModel> indexViewModels = _adminGroupRepository.GetList();

            return View(indexViewModels);
        }


        public ActionResult Create()
        {
			AdminGroupCreateViewModel createViewModel = _adminGroupRepository.Create();

			return View(createViewModel);
        }


        [HttpPost]
        public ActionResult Create(IFormCollection Collection)
        {
            _adminGroupRepository.Create(Collection , HttpContext.Session.GetString("AdminNum"));

            return RedirectToAction(nameof(Index));
        }


        public ActionResult Edit(int id)
        {
            _basic.db_Connection();

            string sqlMenuGroup = "SELECT MenuGroupId, MenuGroupName, MenuGroupIcon FROM MenuGroup";
            string sqlMenuSub = "SELECT MenuSubNum,MenuGroupId, MenuSubId, MenuSubName FROM MenuSub";
            string sqlRole = $"SELECT RoleNum, GroupNum, MenuSubNum, Role FROM AdminRole WHERE GroupNum = {id}";


            string sqlGroup = $"SELECT GroupName, GroupInfo FROM AdminGroup WHERE GroupNum = {id}";
            DataTable dtGroup = _basic.getDataTable(sqlGroup);

            AdminGroupCreateViewModel createViewModel = new AdminGroupCreateViewModel()
            {
                CreatorName = HttpContext.Session.GetString("AdminName")!,
                Creator = Convert.ToInt32(HttpContext.Session.GetString("AdminNum")),
                GroupName = dtGroup.Rows[0]["GroupName"].ToString(),
                GroupInfo = dtGroup.Rows[0]["GroupInfo"].ToString(),
                GroupPublish = 1,

                MenuGroupModels = _basic.getDataTable(sqlMenuGroup),
                MenuSubModels = _basic.getDataTable(sqlMenuSub),
                AdminRoleModels = _basic.getDataTable(sqlRole),
            };


            _basic.db_Close();

            return View(createViewModel);
        }


        [HttpPost]
        public ActionResult Edit(long id, IFormCollection Collection)
        {
            try
            {
                _adminGroupRepository.Edit(id, Collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            _adminGroupRepository.Delete(id);

            return Json("刪除完成");
        }

    }
}
