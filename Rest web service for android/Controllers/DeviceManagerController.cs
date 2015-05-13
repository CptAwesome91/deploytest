using PushSharp;
using PushSharp.Android;
using Rest_web_service_for_android.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Rest_web_service_for_android.Controllers
{
	public class DeviceManagerController : Controller
	{
		private DeviceManagerViewModel ViewModel
		{
			get
			{
				if (Session["ViewModel"] == null)
				{
					DeviceManagerViewModel viewModel = new DeviceManagerViewModel();
					Session["ViewModel"] = viewModel;
				}
				return Session["ViewModel"] as DeviceManagerViewModel;
			}
			set
			{
				if (value != Session["ViewModel"])
				{
					Session["ViewModel"] = value;
				}
			}
		}

		//
		// GET: /DeviceManager/

		public ActionResult Index()
		{
			DeviceManagerViewModel viewModel = new DeviceManagerViewModel();
			return View(ViewModel.Devices);
		}

		[HttpPost]
		public void SendMessage(string message, string deviceId)
		{
			Device device = ViewModel.Devices.Where(x => x.Id == Convert.ToInt32(deviceId)).FirstOrDefault();
			PushBroker pushBroker = new PushBroker();
			pushBroker.RegisterGcmService(new GcmPushChannelSettings("KEYWASREMOVED"));
			pushBroker.QueueNotification(new GcmNotification().ForDeviceRegistrationId(device.RegistrationId)
				.WithJson(@"{""message"":""" + message + @"""}"));
			pushBroker.StopAllServices();
		}
	}
}