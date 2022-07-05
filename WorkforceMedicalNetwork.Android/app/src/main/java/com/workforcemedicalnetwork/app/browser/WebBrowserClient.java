package com.workforcemedicalnetwork.app.browser;

import android.webkit.WebView;
import android.webkit.WebViewClient;

public class WebBrowserClient extends WebViewClient {
    @Override
    public boolean shouldOverrideUrlLoading(WebView view, String url) {
        view.loadUrl(url);
        return true;
    }
}
