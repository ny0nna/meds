using meds.Pages.Notifications;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;



namespace meds.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notification : ContentPage
    {
        INotificationManager notificationManager;
        public Notification()
        {
            InitializeComponent();

            notificationManager = DependencyService.Get<INotificationManager>();
            notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowNotification(evtData.Title, evtData.Message);
            };
        }

        void OnSendClick(object sender, EventArgs e)
        {
            string title = $"Local Notification #";
            string message = $"You have now received notifications!";
            notificationManager.SendNotificationTen(title, message, DateTime.Now.AddSeconds(10));
        }
        public class Interval 
        {
            public int Hours { get; set; }
        }

        

        void OnScheduleClick(object sender, EventArgs e)
        {
            string title = $"Local Notification #";
            string message = $"You have now received notifications!";
            notificationManager.SendNotificationFive(title, message, DateTime.Now.AddSeconds(5));

            
        }

        void ShowNotification(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"Notification Received:\nTitle: {title}\nMessage: {message}"
                };
                stackLayout.Children.Add(msg);
            });
        }
    }
}