using Core_MVC_Example.BackEnd.ViewModel.Member;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core_MVC_Example.Areas.BackEnd.Interface
{
	public interface IMemberRepository
	{
		List<MemberIndexViewModel> GetList();


		void Create(MemberCreateViewModel createViewModel);


		MemberEditViewModel Edit(long id);


		void Edit(MemberEditViewModel editViewModel);


		void Delete(int id);


		void SaveFile(IFormFile file, string savePath);

		void DelFile(long id, string path);
	}
}
