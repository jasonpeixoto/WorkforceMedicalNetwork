package com.workforcemedicalnetwork.app.restapi;

import com.workforcemedicalnetwork.app.restapi.response.*;
import retrofit2.Call;
import retrofit2.http.Field;
import retrofit2.http.FormUrlEncoded;
import retrofit2.http.POST;

public interface ApiInterface
{
    // Register Account
    @FormUrlEncoded             // annotation used in POST type requests
    @POST("/api/location")      // API's endpoints
    Call<LocationResponse> location(@Field("email") String email,
                                    @Field("date") String date,
                                    @Field("latitude") double latitude,
                                    @Field("longitude") double longitude);

    // Register Account
    @FormUrlEncoded             // annotation used in POST type requests
    @POST("/api/register")      // API's endpoints
    Call<RegisterResponse> registration(@Field("name") String name,
                                        @Field("email") String email,
                                        @Field("password") String password);

    // Login
    @FormUrlEncoded             // annotation used in POST type requests
    @POST("/api/login")         // API's endpoints
    Call<LoginResponse> login(@Field("email") String email,
                              @Field("password") String password,
                              @Field("latitude") double latitude,
                              @Field("longitude") double longitude);
}
