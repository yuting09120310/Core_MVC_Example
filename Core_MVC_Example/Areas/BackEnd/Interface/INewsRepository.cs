using Core_MVC_Example.BackEnd.ViewModel.Admin;
using Core_MVC_Example.BackEnd.ViewModel.News;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;

namespace Core_MVC_Example.Areas.BackEnd.Interface
{
	public interface INewsRepository
	{
		List<NewsIndexViewModel> GetList();


		void Create(NewsCreateViewModel createViewModel);


		NewsEditViewModel Edit(int id);


		void Edit(NewsEditViewModel editViewModel);


		void Delete(int id);


		List<SelectListItem> GetGroup();

		void SaveFile(IFormFile file, string savePath);
	}
}
