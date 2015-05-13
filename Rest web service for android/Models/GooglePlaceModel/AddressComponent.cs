using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest_web_service_for_android.Models.GooglePlaceModel
{
	public class AddressComponent
	{
		public string Long_Name { get; set; }

		public string Short_Name { get; set; }

		public IList<GooglePlaceType> Types { get; set; }
	}
}