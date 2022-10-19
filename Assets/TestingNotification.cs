using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class TestingNotification : MonoBehaviour
{
    private void Awake()
    {
        AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler =
            delegate(AndroidNotificationIntentData data)
            {
                var msg = "Notification received : " + data.Id + "\n";
                msg += "\n Notification received: ";
                msg += "\n .Title: " + data.Notification.Title;
                msg += "\n .Body: " + data.Notification.Text;
                msg += "\n .Channel: " + data.Channel;
                Debug.Log($"HANDLER {msg}");
            };

        AndroidNotificationCenter.OnNotificationReceived += receivedNotificationHandler;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START TestingNotification");
        var notification = new AndroidNotification();
        notification.Title = "Your Title";
        notification.Text = "Your Text";
        notification.FireTime = System.DateTime.Now.AddMinutes(1);

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }
}