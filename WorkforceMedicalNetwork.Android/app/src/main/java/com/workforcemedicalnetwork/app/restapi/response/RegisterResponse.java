package com.workforcemedicalnetwork.app.restapi.response;

public class RegisterResponse {
    private boolean authenticated;
    private boolean created;
    private boolean admin;
    private String token;
    private String errorCode;

    public boolean getAuthenticated() { return authenticated; }
    public void setAuthenticated(boolean authenticated) {
        this.authenticated = authenticated;
    }

    public boolean getSuccess() {
        return created;
    }
    public void setSuccess(boolean created) {
        this.created = created;
    }

    public boolean getAdmin() {
        return admin;
    }
    public void setAdmin(boolean admin) {
        this.admin = admin;
    }

    public String getErrorCode() {
        return errorCode;
    }
    public void setErrorCode(String errorCode) {
        this.errorCode = errorCode;
    }

    public String getToken() {
        return token;
    }
    public void setToken(String userid) {
        this.token = userid;
    }
}
