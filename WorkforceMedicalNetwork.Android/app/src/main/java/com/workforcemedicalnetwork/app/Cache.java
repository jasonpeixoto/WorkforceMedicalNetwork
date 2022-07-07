package com.workforcemedicalnetwork.app;

import com.workforcemedicalnetwork.app.gps.GPSTracker;
import com.workforcemedicalnetwork.app.mqtt.MqttClient;
import com.workforcemedicalnetwork.app.ui.MainActivity;

public class Cache {
    private static MqttClient mqttAndroidClient;
    private static GPSTracker gPSTracker;
    private static String emailAddress;
    private static MainActivity mainActivity;
    private static String authToken;

    public static String getEmailAddress() {
        if(emailAddress == null) {
            emailAddress = "";
        }
        return emailAddress;
    }

    public static String setEmailAddress(String emailAddress) {
        return Cache.emailAddress = emailAddress;
    }

    public static GPSTracker getGPSTracker()
    {
        return gPSTracker;
    }

    public static GPSTracker setGPSTracker(GPSTracker gPSTracker) {
        return Cache.gPSTracker = gPSTracker;
    }

    public static MainActivity getMainActivity()
    {
        return mainActivity;
    }

    public static MainActivity setMainActivity(MainActivity mainActivity) {
        return Cache.mainActivity = mainActivity;
    }

    public static MqttClient getMqttAndroidClient()
    {
        return mqttAndroidClient;
    }

    public static MqttClient setMqttAndroidClient(MqttClient mqttAndroidClient) {
        return Cache.mqttAndroidClient = mqttAndroidClient;
    }

    public static String getAuthToken()
    {
        return authToken;
    }

    public static String setAuthToken(String authToken)
    {
        return Cache.authToken = authToken;
    }
}
