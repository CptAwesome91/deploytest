﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest_web_service_for_android.Models.GooglePlaceModel
{
	public class GooglePlaceNearbySearchResult
	{
		public IList<string> Html_Attributions { get; set; }

		public string Status { get; set; }

		public IList<GooglePlace> Results { get; set; }
	}
}