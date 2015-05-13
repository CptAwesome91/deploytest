using Rest_web_service_for_android.Models.GooglePlaceModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Rest_web_service_for_android.Controllers
{
	public class GooglePlacesController : ApiController
	{
		public IList<GooglePlace> Get(string latitude, string longitude, string radius, string types = "", string name = "")
		{
			IList<GooglePlace> result = new List<GooglePlace>();

			NameValueCollection parameters = new NameValueCollection();

			parameters.Add("key", "KEYWASREMOVED");
			parameters.Add("location", latitude.ToString() + "," + longitude.ToString());
			parameters.Add("radius", radius.ToString());
			parameters.Add("sensor", "false");

			if (!string.IsNullOrWhiteSpace(types))
				parameters.Add("types", types);

			if (!string.IsNullOrWhiteSpace(name))
				parameters.Add("name", name);

			string url = "json?" + string.Join("&", parameters.AllKeys.Select(x => string.Format("{0}={1}", HttpUtility.UrlEncode(x), HttpUtility.UrlEncode(parameters[x]))));
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/nearbysearch/");
			HttpResponseMessage response = httpClient.GetAsync(url).Result;
			if (response.IsSuccessStatusCode)
			{
				result = response.Content.ReadAsAsync<GooglePlaceNearbySearchResult>().Result.Results;
			}

			return result;
		}

		public GooglePlaceDetail Get(string reference)
		{
			GooglePlaceDetail result = new GooglePlaceDetail();
			NameValueCollection parameters = new NameValueCollection();
			parameters.Add("key", "KEYWASREMOVED");
			parameters.Add("sensor", "false");
			parameters.Add("reference", reference);

			string url = "json?" + string.Join("&", parameters.AllKeys.Select(x => string.Format("{0}={1}", HttpUtility.UrlEncode(x), HttpUtility.UrlEncode(parameters[x]))));

			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/details/");
			HttpResponseMessage response = httpClient.GetAsync(url).Result;
			if (response.IsSuccessStatusCode)
			{
				result = response.Content.ReadAsAsync<GooglePlaceDetailsResult>().Result.Result;
			}

			return result;
		}

		public IList<GooglePlace> Get()
		{
			return Get("-33.871114", "151.199042", "500", "food", "harbour");
			//GooglePlaceNearbySearchResult gp = new GooglePlaceNearbySearchResult();
			//gp.Html_Attributions = new List<string>() { "Listings by <a href=\"http://www.yellowpages.com.au/\">Yellow Pages</a>" };
			//gp.Results = new List<GooglePlace>();
			//gp.Results.Add(
			//	new GooglePlace()
			//	{
			//		Geometry = new Geometry() { Location = new Location(-33.871114, 151.199042) },
			//		Icon = "http://maps.gstatic.com/mapfiles/place_api/icons/restaurant-71.png",
			//		Id = "ddd678ac0a16d83fdc25500ccb3d6aa27b7f5548",
			//		Name = "Darling Harbour",
			//		Photos = new List<Photo>()
			//		{
			//			new Photo(){
			//				Height=1632,
			//				Html_Attributions =new List<string>(){"<a href=\"https://plus.google.com/118149847494433492210\">Nicole Vessio</a>"},
			//				Photo_Reference="CnRoAAAA71mpjALKFC5YMs-5NQjhUSBDzwNqLbIbMhPLlaI-uVXx99NrQ3nKy7yDhn7EHcmpmFumjBpjzAqzEuR6pBEnOHhAkxtT7LgCX7RELTt8VfMdKfDuel2ld2idSxQ-uR7gUIYlrfdRh85IeXm3Hs-jKBIQROun6pjLmMG547B_355N4RoUtCSfbQo3Op30oLtH_jhu2JAcKuM",
			//				Width=1224}
			//		},
			//		Rating = 4.2,
			//		Reference = "CnRsAAAAV3l12B8BGUAZ3SVkjgHm9F19jUxT-yNJUv-cMBRYRqNY4KuUFa8S17Ogd0XEkRVJ9bga7DXAgXV5sPg9Nh97hF-1xG9lIv0CXhdJH8XbHkViiVrH45r-fJmAuv_ztudi4Bvvj-atc2rzgyoJczovBxIQiAotPRvHsS9f4ND3XJPJMRoUEVXIDumRXRMsYg9cIO3I0F4KdnY",
			//		Types = new List<GooglePlaceType>() { GooglePlaceType.restaurant, GooglePlaceType.food, GooglePlaceType.establishment },
			//		Vicinity = "Sydney"
			//	});
			//gp.Status = "OK";
			//return gp;
		}
	}
}