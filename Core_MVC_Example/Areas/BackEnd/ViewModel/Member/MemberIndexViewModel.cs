﻿using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Core_MVC_Example.BackEnd.ViewModel.Member
{
    public class MemberIndexViewModel
    {
		[Display(Name = "編號")]
		public long MemberNum { get; set; }


		[Display(Name = "帳號")]
		public string MemberAccount { get; set; }


		[Display(Name = "姓名")]
		public string MemberName { get; set; }


		[Display(Name = "電話")]
		public string MemberPhone { get; set; }


		[Display(Name = "信箱")]
		public string MemberEmail { get; set; }


		[Display(Name = "建立時間")]
		public DateTime CreateTime { get; set; }
	}

}
