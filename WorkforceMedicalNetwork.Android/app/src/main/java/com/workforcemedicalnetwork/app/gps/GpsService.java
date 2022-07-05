package com.workforcemedicalnetwork.app.gps;

import retrofit2.Call;
import java.util.Timer;
import android.util.Log;
import retrofit2.Callback;
import retrofit2.Response;
import android.os.Handler;
import android.os.IBinder;
import java.util.TimerTask;
import android.app.Service;
import android.widget.Toast;
import com.google.gson.Gson;
import android.content.Intent;
import com.workforcemedicalnetwork.app.Cache;
import com.workforcemedicalnetwork.app.Constants;
import com.workforcemedicalnetwork.app.utils.Utils;
import org.eclipse.paho.client.mqttv3.MqttException;
import com.workforcemedicalnetwork.app.restapi.APIClient;
import com.workforcemedicalnetwork.app.restapi.ApiInterface;
import com.workforcemedicalnetwork.app.restapi.Request.LocationRequest;
import com.workforcemedicalnetwork.app.restapi.response.LocationResponse;

public class GpsService extends Service {

    private Handler mHandler = new Handler();   //run on another Thread to avoid crash
    private Timer mTimer = null;    //timer handling

    @Override
    public IBinder onBind(Intent intent) {
        throw new UnsupportedOperationException("Not yet implemented");
    }

    @Override
    public void onCreate() {
        if (mTimer != null) {
            mTimer.cancel();
        } else {
            mTimer = new Timer();   //recreate new
        }
        mTimer.scheduleAtFixedRate(new TimeDisplay(), 0, Constants.NotifyGps);   //Schedule task
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        mTimer.cancel();    //For Cancel Timer
        Toast.makeText(this, "Service is Destroyed", Toast.LENGTH_SHORT).show();
    }

    //class TimeDisplay for handling task
    private class TimeDisplay extends TimerTask {
        @Override
        public void run() {
            mHandler.post(new Runnable() {
                @Override
                public void run() {
                    Utils.SendGpsLocation();
                }
            });
        }
    }
}