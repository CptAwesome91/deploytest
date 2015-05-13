using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest_web_service_for_android.ViewModels
{
	public class DeviceManagerViewModel
	{
		private AndroidEntities androidEntities = new AndroidEntities();

		public IEnumerable<Device> Devices {
			get {
				return androidEntities.Devices.AsEnumerable();
			} 
		}
	}
}