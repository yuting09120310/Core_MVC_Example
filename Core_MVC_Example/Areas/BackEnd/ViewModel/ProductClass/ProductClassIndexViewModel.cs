using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Core_MVC_Example.BackEnd.ViewModel.ProductClass
{
    public class ProductClassIndexViewModel
    {
        [Display(Name = "編號")]
        public long ProductClassNum { get; set; }


        [Display(Name = "標題")]
        public string ProductClassName { get; set; }


        [Display(Name = "狀態")]
        public int ProductClassPublish { get; set; }


        [Display(Name = "新增時間")]
        public DateTime CreateTime { get; set; }
    }

}
