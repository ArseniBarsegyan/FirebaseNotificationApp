using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

using Notifications.Data;

namespace FirebaseNotificationApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static readonly string TAG = "MainActivity";

        internal static readonly string CHANNEL_ID = "my_notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;

        TextView msgText;

        public bool IsPlayServicesAvailable()
        {
            msgText = FindViewById<TextView>(Resource.Id.msgText);

            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                else
                {
                    msgText.Text = "This device is not supported";
                    Finish();
                }
                return false;
            }
            else
            {
                msgText.Text = "Google Play Services is available.";
                return true;
            }
        }

        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channelName = AppConstants.NotificationChannelName;
                var channelDescription = string.Empty;
                var channel = new NotificationChannel(channelName, channelName, NotificationImportance.Default)
                {
                    Description = channelDescription
                };

                var notificationManager = (NotificationManager)GetSystemService(NotificationService);
                notificationManager.CreateNotificationChannel(channel);
            }
        }

        protected override void OnNewIntent(Intent intent)
        {
            if (intent.Extras != null)
            {
                var message = intent.GetStringExtra("message");
            }

            base.OnNewIntent(intent);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            IsPlayServicesAvailable();
            CreateNotificationChannel();
        }
    }
}