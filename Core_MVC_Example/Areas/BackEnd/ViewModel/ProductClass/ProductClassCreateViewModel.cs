using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Core_MVC_Example.BackEnd.ViewModel.ProductClass
{
    public class ProductClassCreateViewModel
    {
		[Required(ErrorMessage = "請輸入標題")]
		[Display(Name = "標題")]
        public string ProductClassName { get; set; }


		[Required(ErrorMessage = "請選擇狀態")]
        [Display(Name = "狀態")]
        public int ProductClassPublish { get; set; }
	}

}
