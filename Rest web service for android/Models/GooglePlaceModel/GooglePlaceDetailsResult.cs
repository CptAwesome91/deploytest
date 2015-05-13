using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest_web_service_for_android.Models.GooglePlaceModel
{
	public class GooglePlaceDetailsResult
	{
		public IList<string> Html_Attributions { get; set; }

		public string Status { get; set; }

		public GooglePlaceDetail Result { get; set; }
	}
}