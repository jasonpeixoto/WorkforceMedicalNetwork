package com.workforcemedicalnetwork.app.restapi.Request;

import com.google.gson.annotations.SerializedName;
import com.workforcemedicalnetwork.app.Cache;

public class LocationRequest {
    @SerializedName("email")
    private String email;

    @SerializedName("date")
    private String date;

    @SerializedName("latitude")
    private Double latitude;

    @SerializedName("longitude")
    private Double longitude;

    @SerializedName("token")
    private String token;

    public LocationRequest Create(String email, String date, Double latitude, Double longitude) {
        this.email = email;
        this.date = date;
        this.latitude = latitude;
        this.longitude = longitude;
        this.token = Cache.getAuthToken();
        return this;
    }

    public String getEmail() {
        return email;
    }
    public void setEmail(String email) {
        this.email = email;
    }

    public String getDate() {
        return date;
    }
    public void setDate(String date) {
        this.date = date;
    }

    public Double getLatitude() {
        return latitude;
    }
    public void setLatitude(Double latitude) {
        this.latitude = latitude;
    }

    public Double getLongitude() {
        return longitude;
    }
    public void setLongitude(Double longitude) {
        this.longitude = longitude;
    }

    public String getToken() { return token; }
    public void setToken(String token) {
        this.token = token;
    }
}
