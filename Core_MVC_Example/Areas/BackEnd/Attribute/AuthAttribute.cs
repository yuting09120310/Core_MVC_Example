using Microsoft.AspNetCore.Mvc;

namespace Core_MVC_Example.Areas.BackEnd.Attribute
{
	public class AuthAttribute : TypeFilterAttribute
	{
		public AuthAttribute() : base(typeof(AuthFilter))
		{

		}
	}
}
