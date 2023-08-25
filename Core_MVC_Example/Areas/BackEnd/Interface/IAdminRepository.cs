using Core_MVC_Example.BackEnd.ViewModel.Admin;
using System.Runtime.InteropServices;

namespace Core_MVC_Example.Areas.BackEnd.Interface
{
	public interface IAdminRepository<T> 
	{
		List<T> List();

		List<AdminIndexViewModel> GetList();
	}
}
