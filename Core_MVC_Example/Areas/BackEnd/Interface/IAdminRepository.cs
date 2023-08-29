using Core_MVC_Example.BackEnd.ViewModel.Admin;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;

namespace Core_MVC_Example.Areas.BackEnd.Interface
{
	public interface IAdminRepository
	{
		List<AdminIndexViewModel> GetList();


		void Create(AdminCreateViewModel createViewModel);


		AdminEditViewModel Edit(int id);


		void Edit(AdminEditViewModel editViewModel);


		void Delete(int id);


		List<SelectListItem> GetGroup();


		//List<AdminIndexViewModel> GetList();
	}
}
