using System;
using Unity.Notifications.Android;

namespace AndroidLocalNotifications.Service
{
    public interface IAndroidNotificationService
    {
        void Initialize();
        AndroidNotificationChannel CreateChannel(string channelID, string channelName, Importance importance,
            string description);

        AndroidNotification CreateNotification(string title, string text, DateTime fireTime);
        void RegisterChannel(AndroidNotificationChannel channel);
        void SendNotification(AndroidNotification notification, string channelID);
        void AddNotificationListener(AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler);
        void RemoveNotificationListener(AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler);
    }
}