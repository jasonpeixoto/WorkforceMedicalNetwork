package com.workforcemedicalnetwork.app.restapi;

import com.workforcemedicalnetwork.app.restapi.Request.LocationRequest;
import com.workforcemedicalnetwork.app.restapi.Request.LoginRequest;
import com.workforcemedicalnetwork.app.restapi.Request.RegistrationRequest;
import com.workforcemedicalnetwork.app.restapi.response.*;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.Field;
import retrofit2.http.FormUrlEncoded;
import retrofit2.http.Headers;
import retrofit2.http.POST;

public interface ApiInterface
{
    // Register Account
    @Headers({"accept: application/json", "Content-Type: application/json"})
    @POST("/api/location")      // API's endpoints
    Call<LocationResponse> location(@Body LocationRequest request);

    // Register Account
    @Headers({"accept: application/json", "Content-Type: application/json"})
    @POST("/api/register")      // API's endpoints
    Call<RegisterResponse> registration(@Body RegistrationRequest request);

    // Login
    @Headers({"accept: application/json", "Content-Type: application/json"})
    @POST("/api/login")         // API's endpoints
    Call<LoginResponse> login(@Body LoginRequest request);
}
