using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest_web_service_for_android.Models.GooglePlaceModel
{
	public class Photo
	{
		public int Height { get; set; }

		public IList<string> Html_Attributions { get; set; }

		public string Photo_Reference { get; set; }

		public int Width { get; set; }
	}
}