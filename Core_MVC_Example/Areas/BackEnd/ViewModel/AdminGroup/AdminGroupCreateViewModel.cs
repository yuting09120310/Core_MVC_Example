﻿using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Core_MVC_Example.BackEnd.ViewModel.AdminGroup
{
    public class AdminGroupCreateViewModel
    {
		public int Creator { get; set; }


		[Display(Name = "建立人")]
        public string CreatorName { get; set; }


        [Required(ErrorMessage = "請輸入密碼")]
        [Display(Name = "密碼")]
        public string GroupName { get; set; }


        [Required(ErrorMessage = "請輸入姓名")]
		[Display(Name = "姓名")]
		public string GroupInfo { get; set; }


        [Required(ErrorMessage = "請選擇狀態")]
        [Display(Name = "狀態")]
        public int GroupPublish { get; set; }



        [Display(Name = "大群組")]
        public DataTable MenuGroupModels { get; set; }

        [Display(Name = "小群組")]
        public DataTable MenuSubModels { get; set; }

        [Display(Name = "規則")]
        public DataTable AdminRoleModels { get; set; }
    }

}
