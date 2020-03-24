using System.Threading.Tasks;

using FirebaseAdmin.Messaging;

using Microsoft.AspNetCore.Mvc;

namespace NotificationsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagingController : ControllerBase
    {
        public MessagingController()
        {
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await SendPushNotification(null, "WebApi push", "WebApi push notification", null);
            return Ok();
        }

        public static async Task<bool> SendPushNotification(string[] deviceTokens, string title, string body, object data)
        {
            var registrationToken = "dvV-wzqQd-w:APA91bHREZNCf0O1Vgar7KHLdRZ-INKyGZmG68D8a3HHqxOKRKk1-vZRF6LnpPTK2yrPDrSFlH44460f654m3KiJ2sxiyimmGLYrpdlf2VwQ-rEjRKKQCteMiEQXbgrzUZh7dshc02rY";
            var message = new Message
            {
                Token = registrationToken,
                Notification = new Notification
                {
                    Title = title,
                    Body = body
                }
            };

            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            return true;
        }
    }
}
