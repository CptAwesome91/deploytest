using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Rest_web_service_for_android.Controllers
{
	public class DevicesController : ApiController
	{
		private AndroidEntities androidEntities = new AndroidEntities();
		
		public IEnumerable<Device> Get()
		{
			return androidEntities.Devices.AsEnumerable().Select(x => new Device() { Email = x.Email, Id = x.Id, Name = x.Name });
		}

		public Device Get(int id)
		{
			Device foundDevice = androidEntities.Devices.Where(x => x.Id == id).FirstOrDefault();
			if (foundDevice != null)
				return new Device() { Email = foundDevice.Email, Id = foundDevice.Id, Name = foundDevice.Name };
			else
				return null;
		}

		public Device Post(string name, string email, string registrationId)
		{
			if (!string.IsNullOrWhiteSpace(registrationId))
			{
				Device device = androidEntities.Devices.Where(x => x.RegistrationId == registrationId).FirstOrDefault();
				if (device == null)
				{
					device = new Device();
					androidEntities.Devices.Add(device);
				}

				device.Email = email;
				device.Name = name;
				device.RegistrationId = registrationId;


				androidEntities.SaveChanges();
				return device;
			}
			else
				return null;
		}

		public void Delete(string registrationId)
		{
			Device device = androidEntities.Devices.Where(x => x.RegistrationId == registrationId).FirstOrDefault();
			if (device != null)
			{
				androidEntities.Devices.Remove(device);
			}
			androidEntities.SaveChanges();
		}
	}
}