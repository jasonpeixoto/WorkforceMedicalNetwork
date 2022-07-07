package com.workforcemedicalnetwork.app.utils;

import retrofit2.Call;
import android.util.Log;
import retrofit2.Callback;
import retrofit2.Response;
import java.util.Calendar;
import java.text.DateFormat;
import com.google.gson.Gson;
import android.app.Activity;
import android.content.Intent;
import android.app.AlertDialog;
import android.content.Context;
import java.text.SimpleDateFormat;
import android.content.DialogInterface;
import com.workforcemedicalnetwork.app.Cache;
import com.workforcemedicalnetwork.app.Constants;
import org.eclipse.paho.client.mqttv3.MqttException;
import com.workforcemedicalnetwork.app.ui.MainActivity;
import com.workforcemedicalnetwork.app.ui.SplashActivity;
import com.workforcemedicalnetwork.app.restapi.APIClient;
import com.workforcemedicalnetwork.app.restapi.ApiInterface;
import com.workforcemedicalnetwork.app.restapi.Request.LocationRequest;
import com.workforcemedicalnetwork.app.restapi.response.LocationResponse;

public class Utils {

    public static String GetCurrentDateTime() {
        DateFormat df = new SimpleDateFormat("MM/dd/yyyy HH:mm:ss.SSS Z");
        return df.format(Calendar.getInstance().getTime());
    }

    public static Boolean LoginUser(Context context, String email, String token) {
        Cache.setEmailAddress(email);
        Cache.setAuthToken(token);
        if(!email.isEmpty() && !token.isEmpty()) {
            Utils.SendGpsLocation();
            Intent i = new Intent(context, SplashActivity.class);
            i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK | Intent.FLAG_ACTIVITY_CLEAR_TOP);
            context.startActivity(i);
            return true;
        }
        return false;
    }

    public static  Boolean IsLoggedIn(Context context) {
        if(Cache.getAuthToken().isEmpty()) {
            Intent i = new Intent(context, MainActivity.class);
            i.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK | Intent.FLAG_ACTIVITY_CLEAR_TOP);
            context.startActivity(i);
        }
        return !Cache.getAuthToken().isEmpty();
    }

    private static Gson gson = new Gson();
    public static void SendGpsLocation() {
        if (Cache.getEmailAddress().isEmpty()) return;

        LocationRequest locationRequest = new LocationRequest();
        locationRequest.Create(
                Cache.getEmailAddress(),
                Utils.GetCurrentDateTime(),
                Cache.getGPSTracker().getLatitude(),
                Cache.getGPSTracker().getLongitude()
        );

        if (Constants.EnableApi == true) {
            ApiInterface apiService = APIClient.getClient().create(ApiInterface.class);
            Call<LocationResponse> apiCall = apiService.location(locationRequest);

            apiCall.enqueue(new Callback<LocationResponse>() {
                @Override
                public void onResponse(Call<LocationResponse> call, Response<LocationResponse> response) {
                    // success
                }

                @Override
                public void onFailure(Call<LocationResponse> call, Throwable t) {
                    Log.d("response", t.getStackTrace().toString());
                }
            });
        }

        if (Constants.EnableMqtt == true) {
            String json = gson.toJson(locationRequest);
            try {
                Cache.getMqttAndroidClient().Publish("/location", json);
            } catch (MqttException e) {
                e.printStackTrace();
            }
        }
    }

    public static void AskToExit(final Activity context, String title) {
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        builder.setCancelable(false);
        builder.setMessage(title);
        builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                //if user pressed "yes", then he is allowed to exit from application
                context.finish();
            }
        });
        builder.setNegativeButton("No",new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                //if user select "No", just cancel this dialog and continue with app
                dialog.cancel();
            }
        });
        AlertDialog alert=builder.create();
        alert.show();
    }
}
