namespace Notifications.Data
{
    public static class AppConstants
    {
        public static string NotificationChannelName { get; set; } = "XamarinNotifyChannel";
        public static string NotificationHubName { get; set; } = "PushAppNotificationsHub";
        public static string ListenConnectionString { get; set; } = "Endpoint=sb://pushappnotificationshub.servicebus.windows.net/;SharedAccessKeyName=ListenPolicy;SharedAccessKey=6OtN6Ds/1uVAxN+fu4vJlnCFBkuEu/FYfTBGEmLOIss=";
        public static string DebugTag { get; set; } = "XamarinNotify";
        public static string[] SubscriptionTags { get; set; } = { "default" };
        public static string FCMTemplateBody { get; set; } = "{\"data\":{\"message\":\"$(messageParam)\"}}";
        public static string APNTemplateBody { get; set; } = "{\"aps\":{\"alert\":\"$(messageParam)\"}}";
    }
}
