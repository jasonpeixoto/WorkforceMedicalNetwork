package com.workforcemedicalnetwork.app.restapi.Request;

import com.google.gson.annotations.SerializedName;

public class RegistrationRequest {
    @SerializedName("fullName")
    private String fullName;

    @SerializedName("email")
    private String email;

    @SerializedName("password")
    private String password;

    @SerializedName("admin")
    private Boolean admin;

    @SerializedName("date")
    private String date;

    @SerializedName("latitude")
    private Double latitude;

    @SerializedName("longitude")
    private Double longitude;

    @SerializedName("token")
    private String token;

    public RegistrationRequest Create(String fullName, String email, String password, String date, Double latitude, Double longitude) {
        this.fullName = fullName;
        this.email = email;
        this.date = date;
        this.latitude = latitude;
        this.longitude = longitude;
        this.password = password;
        return this;
    }
    public String getFullName() {
        return fullName;
    }
    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public String getEmail() {
        return email;
    }
    public void setEmail(String email) {
        this.email = email;
    }

    public Boolean getAdmin() {
        return admin;
    }
    public void setAdmin(Boolean admin) { this.admin = admin; }

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

    public String getPassword() { return password; }
    public void setPassword(String password) {
        this.password = password;
    }

    public String getToken() { return token; }
    public void setToken(String token) {
        this.token = token;
    }
}

