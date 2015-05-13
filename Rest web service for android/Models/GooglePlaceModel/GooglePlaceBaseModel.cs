using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest_web_service_for_android.Models.GooglePlaceModel
{
	public class GooglePlaceBaseModel
	{
		public Geometry Geometry { get; set; }

		public string Icon { get; set; }

		public string Id { get; set; }

		public string Name { get; set; }

		public IList<Photo> Photos { get; set; }

		public double Rating { get; set; }

		public string Reference { get; set; }

		public IList<GooglePlaceType> Types { get; set; }

		public string Vicinity { get; set; }
	}
}