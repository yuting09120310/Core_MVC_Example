using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Core_MVC_Example.BackEnd.ViewModel.Product
{
	public class ProductEditViewModel
	{
		[Display(Name = "編號")]
		public long ProductNum { get; set; }


		[Required(ErrorMessage = "請選擇分類")]
		[Display(Name = "分類")]
		public int ProductClassNum { get; set; }


		[Required(ErrorMessage = "請輸入標題")]
		[Display(Name = "標題")]
		public string ProductTitle { get; set; }


		[Display(Name = "圖片")]
		public IFormFile? ProductImg { get; set; }


		[Required(ErrorMessage = "請輸入描述")]
		[Display(Name = "描述")]
		public string ProductDescription { get; set; }


		[Required(ErrorMessage = "請輸入內容")]	
		[Display(Name = "內容")]
		public string ProductContent { get; set; }


		[Display(Name = "排序")]
		public int? Sort { get; set; }


		[Display(Name = "上架日期")]
		public DateTime ProductPutTime { get; set; }


		[Display(Name = "下架日期")]
		public DateTime ProductOffTime { get; set; }


		[Required(ErrorMessage = "請選擇狀態")]
		[Display(Name = "狀態")]
		public int ProductPublish { get; set; }


		[Display(Name = "編輯人")]
		public int Editor { get; set; }


		[Display(Name = "編輯時間")]
		public DateTime EditTime { get; set; }
		
	}
}