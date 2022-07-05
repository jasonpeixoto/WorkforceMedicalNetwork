package com.workforcemedicalnetwork.app.restapi.Request;

public class LocationRequest {
    private String email;
    private String date;
    private Double latitude;
    private Double longitude;

    public LocationRequest Create(String email, String date, Double latitude, Double longitude) {
        this.email = email;
        this.date = date;
        this.latitude = latitude;
        this.longitude = longitude;
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
}
