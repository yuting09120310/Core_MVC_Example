using Core_MVC_Example.BackEnd.ViewModel.News;
using Core_MVC_Example.BackEnd.ViewModel.NewsClass;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core_MVC_Example.Areas.BackEnd.Interface
{
	public interface INewsClassRepository
    {
		List<NewsClassIndexViewModel> GetList();


        NewsClassCreateViewModel Create();
        void Create(NewsClassCreateViewModel createViewModel, string AdminNum);


        NewsClassEditViewModel Edit(long id);
		void Edit(NewsClassEditViewModel editViewModel, string AdminNum);


		void Delete(int id);
	}
}
