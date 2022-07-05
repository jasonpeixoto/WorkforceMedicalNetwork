package com.workforcemedicalnetwork.app;

import java.util.ArrayList;
import com.workforcemedicalnetwork.app.models.ImageData;

public class Constants {
    public static Boolean UseInternalBrowser = true;
    public static Boolean EnableMqtt = true;
    public static Boolean EnableApi = false;
    public static String EndPoint = "http://127.0.0.1/";
    public static String MqttUrl = "tcp://159.203.93.5:1883";
    public static int NotifyGps = 5 * 60 * 1000;

    private static ArrayList<ImageData> arrayList;
    public static ArrayList<ImageData> getImageLinks() {
        if(arrayList == null) {
            arrayList = new ArrayList<ImageData>();
            arrayList.add(new ImageData("I NEED A DOCTOR!", "http://workforcemedicalnetwork.com/", "@drawable/need_a_doctor"));
            arrayList.add(new ImageData("I NEED AN ATTORNEY!", "http://workforcemedicalnetwork.com/", "@drawable/need_an_attorney"));
            arrayList.add(new ImageData("I NEED A TEAM!", "http://workforcemedicalnetwork.com/", "@drawable/need_a_team"));
        }
        return arrayList;
    }
}
