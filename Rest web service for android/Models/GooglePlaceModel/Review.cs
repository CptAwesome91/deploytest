using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest_web_service_for_android.Models.GooglePlaceModel
{
	public class Review
	{
		public IList<Aspect> Aspects { get; set; }

		public string Author_Name { get; set; }

		public string Author_Url { get; set; }

		public string Text { get; set; }

		public string Time { get; set; }
	}
}