using Foundation;

using UIKit;

namespace FirebaseNotificationApp.Ios
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Firebase.Core.App.Configure();

            Window = new UIWindow(UIScreen.MainScreen.Bounds)
            {
                RootViewController = new UIViewController()
            };

            Window.MakeKeyAndVisible();

            return true;
        }

        public override void OnResignActivation(UIApplication application)
        {
        }

        public override void DidEnterBackground(UIApplication application)
        {
        }

        public override void WillEnterForeground(UIApplication application)
        {
        }

        public override void OnActivated(UIApplication application)
        {
        }

        public override void WillTerminate(UIApplication application)
        {
        }
    }
}
