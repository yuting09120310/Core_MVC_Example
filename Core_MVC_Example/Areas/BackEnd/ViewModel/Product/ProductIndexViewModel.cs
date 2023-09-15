using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Core_MVC_Example.BackEnd.ViewModel.Product
{
    public class ProductIndexViewModel
	{
        [Display(Name = "編號")]
        public long ProductNum { get; set; }

		[Display(Name = "分類")]
        public string ProductClassName { get; set; }

        [Display(Name = "標題")]
        public string ProductTitle { get; set; }

        [Display(Name = "狀態")]
        public int ProductPublish { get; set; }

        [Display(Name = "新增時間")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "更新時間")]
        public DateTime? EditTime { get; set; }
    }

}
