using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest_web_service_for_android.Models.GooglePlaceModel
{
	public class GooglePlaceDetail : GooglePlaceBaseModel
	{
		public IList<AddressComponent> Address_Components { get; set; }

		public string Formatted_Address { get; set; }

		public string Formatted_Phone_Number { get; set; }

		public string International_Phone_Number { get; set; }

		public IList<Review> Reviews { get; set; }

		public string Url { get; set; }

		public string Utc_Offset { get; set; }

		public string Website { get; set; }
	}
}