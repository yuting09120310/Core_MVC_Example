﻿using Core_MVC_Example.BackEnd.ViewModel.News;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core_MVC_Example.Areas.BackEnd.Interface
{
	public interface INewsRepository
	{
		List<NewsIndexViewModel> GetList();


		void Create(NewsCreateViewModel createViewModel);


		NewsEditViewModel Edit(long id, string path);


		void Edit(NewsEditViewModel editViewModel);


		void Delete(int id);


		List<SelectListItem> GetGroup();

		void SaveFile(IFormFile file, string savePath);

		void DelFile(long id, string path);
	}
}
