using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest_web_service_for_android.Models.GooglePlaceModel
{
	public class GooglePlace : GooglePlaceBaseModel
	{
		public OpeningHour Opening_Hours { get; set; }

		public int Price_Level { get; set; }
	}
}