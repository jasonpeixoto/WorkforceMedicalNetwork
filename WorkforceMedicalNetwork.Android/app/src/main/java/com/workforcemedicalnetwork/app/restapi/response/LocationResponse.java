package com.workforcemedicalnetwork.app.restapi.response;

public class LocationResponse {
    private boolean login;
    private boolean success;
    private String errorCode;

    public boolean getSuccess() { return success; }
    public void setSuccess(boolean success) {
        this.success = success;
    }

    public boolean getLogin() { return login; }
    public void setLogin(boolean login) {
        this.login = login;
    }

    public String getErrorCode() {
        return errorCode;
    }
    public void setErrorCode(String errorCode) { this.errorCode = errorCode; }
}
