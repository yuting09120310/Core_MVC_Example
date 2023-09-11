﻿using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Core_MVC_Example.BackEnd.ViewModel.NewsClass
{
	public class NewsClassEditViewModel
    {
        public long NewsClassNum { get; set; }


        [Required(ErrorMessage = "請輸入標題")]
        [Display(Name = "標題")]
        public string NewsClassName { get; set; }


        [Required(ErrorMessage = "請選擇狀態")]
        [Display(Name = "狀態")]
        public int NewsClassPublish { get; set; }
    }
}