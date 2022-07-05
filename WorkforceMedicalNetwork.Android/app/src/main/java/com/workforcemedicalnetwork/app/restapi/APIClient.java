package com.workforcemedicalnetwork.app.restapi;

import com.workforcemedicalnetwork.app.Constants;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import java.util.concurrent.TimeUnit;
import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.RequestBody;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class APIClient {
    private static Retrofit retrofit = null;
    private static final Object LOCK = new Object();

    public static void clear() {
        synchronized (LOCK) {
            retrofit = null;
        }
    }

    public static Retrofit getClient() {
        synchronized (LOCK) {
            if (retrofit == null) {

                Gson gson = new GsonBuilder()
                        .setLenient()
                        .create();

                OkHttpClient okHttpClient = new OkHttpClient().newBuilder()
                        .connectTimeout(40, TimeUnit.SECONDS)
                        .readTimeout(60, TimeUnit.SECONDS)
                        .writeTimeout(60, TimeUnit.SECONDS)
                        .build();


                retrofit = new Retrofit.Builder()
                        .client(okHttpClient)
                        .baseUrl(Constants.EndPoint)
                        .addConverterFactory(GsonConverterFactory.create(gson))
                        .build();
            }
            return retrofit;
        }

    }

    public static RequestBody plain(String content) {
        return getRequestBody("text/plain", content);
    }

    public static RequestBody getRequestBody(String type, String content) {
        return RequestBody.create(MediaType.parse(type), content);
    }
}
