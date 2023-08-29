using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OBizCommonClass;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;

namespace Core_MVC_Example.Areas.BackEnd.Filter
{
	public class AuthAttribute : TypeFilterAttribute
	{
		public AuthAttribute() : base(typeof(AuthFilter))
		{

		}
	}
}
