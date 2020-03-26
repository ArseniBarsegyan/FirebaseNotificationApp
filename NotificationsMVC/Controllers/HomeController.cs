using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NotificationsMVC.Configuration;
using NotificationsMVC.Models;
using NotificationsMVC.NotificationHubs;

namespace NotificationsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly NotificationHubProxy _notificationHubProxy;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IOptions<NotificationHubConfiguration> standardNotificationHubConfiguration)
        {
            _logger = logger;
            _notificationHubProxy = new NotificationHubProxy(standardNotificationHubConfiguration.Value);
        }

        public IActionResult Index()
        {
            var devices = _notificationHubProxy.GetAllRegisteredDevices();
            return View();
        }

        public IActionResult Privacy()
        {            
            return View();
        }

        public async Task<IActionResult> Notification()
        {
            // var registrationId = await _notificationHubProxy.CreateRegistrationId();

            //await _notificationHubProxy.RegisterForPushNotifications("2850911781021882943-5805015826368575877-3", new DeviceRegistration
            //{
            //    Platform = MobilePlatform.GoogleCloudMessaging
            //});

            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(NotificationHubs.Notification newNotification)
        {
            HubResponse<NotificationOutcome> pushDeliveryResult = await _notificationHubProxy.SendNotification(newNotification);

            if (pushDeliveryResult.CompletedWithSuccess)
                return Ok();

            return BadRequest("An error occurred while sending push notification: " + pushDeliveryResult.FormattedErrorMessages);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
