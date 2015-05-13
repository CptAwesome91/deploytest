using System.Web;
using System.Web.Mvc;

namespace Rest_web_service_for_android
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}