package com.workforcemedicalnetwork.app.restapi.response;

public class LoginResponse {
    private boolean authenticated;
    private String token;
    private String errorCode;

    public boolean getAuthenticated() { return authenticated; }
    public void setAuthenticated(boolean authenticated) {
        this.authenticated = authenticated;
    }

    public String getErrorCode() {
        return errorCode;
    }
    public void setErrorCode(String errorCode) { this.errorCode = errorCode; }

    public String getToken() {
        return token;
    }
    public void setToken(String userid) {
        this.token = userid;
    }
}
