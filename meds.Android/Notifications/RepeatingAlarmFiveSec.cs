using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meds.Pages.Notifications;
using static meds.Pages.Notification;

namespace meds.Droid.Notifications
{
    [BroadcastReceiver]
public class RepeatingAlarmFiveSec : BroadcastReceiver
{
        public override void OnReceive(Context context, Intent intent)
        {
            //Every time the `RepeatingAlarm` is fired, set the next alarm
            var intentForRepeat = new Intent(context, typeof(RepeatingAlarmFiveSec));
            var source = PendingIntent.GetBroadcast(context, 0, intent, 0);
            var am = (AlarmManager)Android.App.Application.Context.GetSystemService(Context.AlarmService);
            am.SetExactAndAllowWhileIdle(AlarmType.ElapsedRealtimeWakeup, SystemClock.ElapsedRealtime() +  5 * 1000, source);

            Toast.MakeText(context, "пора пить таблетки 5sec", ToastLength.Long).Show();
        }
}
}