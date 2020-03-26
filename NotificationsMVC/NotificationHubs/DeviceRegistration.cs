using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NotificationsMVC.NotificationHubs
{
    public class DeviceRegistration
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public MobilePlatform Platform { get; set; } = MobilePlatform.GoogleCloudMessaging;
        public string Handle { get; set; }
        public string[] Tags { get; set; }
    }
}
