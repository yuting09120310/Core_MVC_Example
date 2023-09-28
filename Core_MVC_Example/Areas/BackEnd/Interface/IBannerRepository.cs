using Core_MVC_Example.BackEnd.ViewModel.Banner;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core_MVC_Example.Areas.BackEnd.Interface
{
	public interface IBannerRepository
	{
		List<BannerIndexViewModel> GetList();


		void Create(BannerCreateViewModel createViewModel);


		BannerEditViewModel Edit(long id, string path);


		void Edit(BannerEditViewModel editViewModel);


		void Delete(int id);


		void SaveFile(IFormFile file, string savePath);

		void DelFile(long id, string path);
	}
}
