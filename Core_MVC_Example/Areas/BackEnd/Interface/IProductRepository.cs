using Core_MVC_Example.BackEnd.ViewModel.Product;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core_MVC_Example.Areas.BackEnd.Interface
{
    public interface IProductRepository
	{
		List<ProductIndexViewModel> GetList();


        ProductCreateViewModel Create();
        void Create(ProductCreateViewModel createViewModel);


		ProductEditViewModel Edit(long id, string path);
		void Edit(ProductEditViewModel editViewModel);


		void Delete(int id);


		List<SelectListItem> GetGroup();

		void SaveFile(IFormFile file, string savePath);

		void DelFile(long id, string path);
	}
}
