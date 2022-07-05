package com.workforcemedicalnetwork.app.restapi.response;

public class RegisterResponse {
    private String success;
    private String message;
    private String userid;

    public String getSuccess() {
        return success;
    }
    public void setSuccess(String success) {
        this.success = success;
    }

    public String getMessage() {
        return message;
    }
    public void setMessage(String message) {
        this.message = message;
    }

    public String getUserid() {
        return userid;
    }
    public void setUserid(String userid) {
        this.userid = userid;
    }
}
