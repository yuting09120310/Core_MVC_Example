using Core_MVC_Example.BackEnd.ViewModel.Admin;
using Core_MVC_Example.BackEnd.ViewModel.AdminGroup;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;

namespace Core_MVC_Example.Areas.BackEnd.Interface
{
	public interface IAdminGroupRepository
	{
		List<AdminGroupIndexViewModel> GetList();


		AdminGroupCreateViewModel Create();
		void Create(IFormCollection Collection);


		AdminGroupEditViewModel Edit(int id);


		void Edit(long id, IFormCollection Collection);


		void Delete(int id);
	}
}
