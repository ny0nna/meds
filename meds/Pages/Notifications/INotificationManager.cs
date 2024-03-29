﻿using System;
using System.Collections.Generic;
using System.Text;

namespace meds.Pages.Notifications
{
    public interface INotificationManager
    {
        event EventHandler NotificationReceived;
        void Initialize();
        void SendNotificationFive(string title, string message, DateTime? notifyTime = null);
        void SendNotification(string title, string message, DateTime? notifyTime = null);
        void ReceiveNotification(string title, string message);
    }
}
