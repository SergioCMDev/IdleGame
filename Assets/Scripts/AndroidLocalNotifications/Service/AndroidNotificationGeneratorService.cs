// using System;
// using System.Collections;
// using Unity.Notifications.Android;
// using UnityEngine;
// using UnityEngine.Android;
// using Utils;
//
// namespace AndroidLocalNotifications.Service
// {
//     public class AndroidNotificationGeneratorService : IAndroidNotificationService
//     {
//         private CoroutineExecutioner _coroutineExecutioner;
//         private bool _initialize;
//
//         public void Initialize()
//         {
//             if (_initialize) return;
//             _coroutineExecutioner = ServiceLocator.Instance.GetService<CoroutineExecutioner>();
//             if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
//             {
//                 Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
//             }
//
//             Debug.Log("[AndroidNotificationGeneratorService] Iniciamos inicializacion");
//             _coroutineExecutioner.StartChildCoroutine(InitializeNotificationCenter());
//             Debug.Log("[AndroidNotificationGeneratorService] Inicializacion correcta");
//             CancelNotifications(true);
//             _initialize = true;
//         }
//
//         private IEnumerator InitializeNotificationCenter()
//         {
//             var status = AndroidNotificationCenter.Initialize();
//             if (status) yield break;
//             yield return new WaitForSeconds(1);
//         }
//
//         public AndroidNotificationChannel CreateChannel(string channelID, string channelName, Importance importance,
//             string description)
//         {
//             return new AndroidNotificationChannel()
//             {
//                 Id = channelID,
//                 Name = channelName,
//                 Importance = importance,
//                 Description = description,
//                 CanShowBadge = true,
//             };
//         }
//
//         public AndroidNotification CreateNotification(string title, string text, DateTime fireTime)
//         {
//             var notification = new AndroidNotification
//             {
//                 Title = title,
//                 Text = text,
//                 FireTime = fireTime
//             };
//             return notification;
//         }
//
//         public void RegisterChannel(AndroidNotificationChannel channel)
//         {
//             AndroidNotificationCenter.RegisterNotificationChannel(channel);
//         }
//
//         public void SendNotification(AndroidNotification notification, string channelID)
//         {
//             AndroidNotificationCenter.SendNotification(notification, channelID);
//         }
//
//         public void AddNotificationListener(
//             AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler)
//         {
//             AndroidNotificationCenter.OnNotificationReceived += receivedNotificationHandler;
//         }
//
//         public void RemoveNotificationListener(
//             AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler)
//         {
//             AndroidNotificationCenter.OnNotificationReceived -= receivedNotificationHandler;
//         }
//
//         private void CancelNotifications(bool cancelDisplayed = false)
//         {
// #if UNITY_ANDROID
//         AndroidNotificationCenter.CancelAllScheduledNotifications();
//         if (cancelDisplayed)
//         {
//             AndroidNotificationCenter.CancelAllDisplayedNotifications();
//         }
// #endif
// #if UNITY_IOS
//             iOSNotificationCenter.RemoveAllScheduledNotifications();
//             if (cancelDisplayed)
//             {
//                 iOSNotificationCenter.RemoveAllDeliveredNotifications();
//             }
// #endif
//         }
//     }
// }