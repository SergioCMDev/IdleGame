using AndroidLocalNotifications.Service;
using Unity.Notifications.Android;
using UnityEngine;
using Utils;

namespace AndroidLocalNotifications
{
    public class TestingNotification : MonoBehaviour
    {
        private IAndroidNotificationService _androidNotificationService;
        

        private void ReceivedNotificationHandler(AndroidNotificationIntentData data)
        {
            var msg = "Notification received : " + data.Id + "\n";
            msg += "\n Notification received: ";
            msg += "\n .Title: " + data.Notification.Title;
            msg += "\n .Body: " + data.Notification.Text;
            msg += "\n .Channel: " + data.Channel;
            Debug.Log($"HANDLER {msg}");
        }

        void Start()
        {
            _androidNotificationService = ServiceLocator.Instance.GetService<IAndroidNotificationService>();
            _androidNotificationService.AddNotificationListener(ReceivedNotificationHandler);
            var channelID = "channel_id";
            _androidNotificationService.Initialize();
            var channel = _androidNotificationService.CreateChannel(channelID, "SpeedySquare", Importance.High,
                "a description for your channel");

            _androidNotificationService.RegisterChannel(channel);
            var notification = _androidNotificationService.CreateNotification("Your Title", "Your Text",
                System.DateTime.Now.AddMinutes(1));

            _androidNotificationService.SendNotification(notification, channelID);
            Debug.Log("SENT TestingNotification");
        }
    }
}