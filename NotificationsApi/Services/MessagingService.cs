using System.Threading.Tasks;

using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Options;

using NotificationsApi.Configuration;
using NotificationsApi.NotificationHubs;

namespace NotificationsApi.Services
{
    public class MessagingService
    {
        private readonly NotificationHubProxy _notificationHubProxy;

        public MessagingService(IOptions<NotificationHubConfiguration> standardNotificationHubConfiguration)
        {
            _notificationHubProxy = new NotificationHubProxy(standardNotificationHubConfiguration.Value);
        }

        public async Task<bool> SendNotification(NotificationHubs.Notification newNotification)
        {
            HubResponse<NotificationOutcome> pushDeliveryResult = await _notificationHubProxy.SendNotification(newNotification);

            if (pushDeliveryResult.CompletedWithSuccess)
                return true;

            return false;
        }
    }
}
