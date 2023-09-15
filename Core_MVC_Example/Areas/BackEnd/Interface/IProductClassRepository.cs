using Core_MVC_Example.BackEnd.ViewModel.News;
using Core_MVC_Example.BackEnd.ViewModel.NewsClass;
using Core_MVC_Example.BackEnd.ViewModel.ProductClass;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core_MVC_Example.Areas.BackEnd.Interface
{
	public interface IProductClassRepository
    {
		List<ProductClassIndexViewModel> GetList();


        ProductClassCreateViewModel Create();
        void Create(ProductClassCreateViewModel createViewModel, string AdminNum);


        ProductClassEditViewModel Edit(long id);
		void Edit(ProductClassEditViewModel editViewModel, string AdminNum);


		void Delete(int id);
	}
}
