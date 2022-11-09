using System;
using System.Collections;
using AndroidLocalNotifications.Service;
using Services.Utils;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.Android;
using Utils;

namespace Services.AndroidNotification
{
    [CreateAssetMenu(fileName = "AndroidNotificationInitializer",
        menuName = "Loadable/Services/AndroidNotificationInitializer")]
    public class AndroidNotificationService : LoadableComponent, IAndroidNotificationService
    {
        private CoroutineExecutioner _coroutineExecutioner;
        private bool _initialize;

        public override void Execute()
        {
            Debug.Log("[AndroidNotificationService] Init");
            if (_initialize) return;
            _coroutineExecutioner = ServiceLocator.Instance.GetService<CoroutineExecutioner>();
            if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
            {
                Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
            }

            Debug.Log("[AndroidNotificationService] Iniciamos inicializacion");
            _coroutineExecutioner.StartChildCoroutine(InitializeNotificationCenter());
            Debug.Log("[AndroidNotificationService] Inicializacion correcta");
            CancelNotifications(true);
            _initialize = true;
            Debug.Log("[AndroidNotificationService] Init");
        }

        private IEnumerator InitializeNotificationCenter()
        {
            var status = AndroidNotificationCenter.Initialize();
            if (status) yield break;
            yield return new WaitForSeconds(1);
        }

        public void Initialize()
        {
            Execute();
        }

        public AndroidNotificationChannel CreateChannel(string channelID, string channelName, Importance importance,
            string description)
        {
            return new AndroidNotificationChannel()
            {
                Id = channelID,
                Name = channelName,
                Importance = importance,
                Description = description,
                CanShowBadge = true,
            };
        }
        
        public Unity.Notifications.Android.AndroidNotification CreateNotification(string title, string text, DateTime fireTime)
        {
            var notification = new Unity.Notifications.Android.AndroidNotification
            {
                Title = title,
                Text = text,
                FireTime = fireTime
            };
            return notification;
        }

        public void RegisterChannel(AndroidNotificationChannel channel)
        {
            AndroidNotificationCenter.RegisterNotificationChannel(channel);
        }
        
        public void SendNotification(Unity.Notifications.Android.AndroidNotification notification, string channelID)
        {
            AndroidNotificationCenter.SendNotification(notification, channelID);
        }

        public void AddNotificationListener(
            AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler)
        {
            AndroidNotificationCenter.OnNotificationReceived += receivedNotificationHandler;
        }

        public void RemoveNotificationListener(
            AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler)
        {
            AndroidNotificationCenter.OnNotificationReceived -= receivedNotificationHandler;
        }

        private void CancelNotifications(bool cancelDisplayed = false)
        {
#if UNITY_ANDROID
            AndroidNotificationCenter.CancelAllScheduledNotifications();
            if (cancelDisplayed)
            {
                AndroidNotificationCenter.CancelAllDisplayedNotifications();
            }
#endif
#if UNITY_IOS
            iOSNotificationCenter.RemoveAllScheduledNotifications();
            if (cancelDisplayed)
            {
                iOSNotificationCenter.RemoveAllDeliveredNotifications();
            }
#endif
        }
    }
}