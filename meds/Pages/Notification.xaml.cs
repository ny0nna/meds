using Android.Content;
using meds.Pages.Notifications;
using System;
using System.ComponentModel;
using System.Diagnostics;
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
            string title = $"Учебное уведомление";
            string message = $"Пора пить лекарства!";
            notificationManager.SendNotification(title, message, DateTime.Now.AddSeconds(10));
        }
        
        
        void OnScheduleClick(object sender, EventArgs e)
        {
            string title = $"Local Notification #";
            string message = $"You have now received notifications!";
            notificationManager.SendNotificationFive(title, message, DateTime.Now.AddSeconds(5));
        }

        /*void StopClick(object sender, EventArgs e)
        {
            
        } */   

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