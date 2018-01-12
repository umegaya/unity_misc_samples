using UnityEngine;
using System.Collections;
#if UNITY_IPHONE
using iOS = UnityEngine.iOS;
#elif UNITY_ANDROID
using Android = Assets.SimpleAndroidNotifications;
#endif

public class LocalNotification : MonoBehaviour {
	public static LocalNotification instance {
		get; private set;
	}

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (this != instance) {
			DestroyImmediate(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
	}

    void Start() {
#if UNITY_IPHONE
        iOS.NotificationServices.RegisterForNotifications(
            iOS.NotificationType.Alert | 
            iOS.NotificationType.Badge | 
            iOS.NotificationType.Sound);
#elif UNITY_ANDROID
#else
#endif
    }

    public void SetNotification(string title, string message, int delayTime, int badgeNumber = 1){
#if UNITY_IPHONE
        var l = new iOS.LocalNotification();
        l.applicationIconBadgeNumber = badgeNumber;
        l.fireDate = System.DateTime.Now.AddSeconds(delayTime);
        l.alertAction = title;
        l.alertBody = message;
        iOS.NotificationServices.ScheduleLocalNotification(l);
#elif UNITY_ANDROID
        Android.NotificationManager.Send(System.TimeSpan.FromSeconds(delayTime), title, message, new Color(1, 0.3f, 0.15f));
#else
#endif
    }

    public void Clear() {
#if UNITY_IPHONE
		iOS.NotificationServices.CancelAllLocalNotifications();
#elif UNITY_ANDROID
		Android.NotificationManager.CancelAll();
#else
#endif    	
    }
}
