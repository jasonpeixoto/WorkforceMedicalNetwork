package com.workforcemedicalnetwork.app.ui;

import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView;
import androidx.annotation.NonNull;
import android.view.LayoutInflater;
import androidx.fragment.app.Fragment;
import com.workforcemedicalnetwork.app.R;
import com.workforcemedicalnetwork.app.browser.WebBrowserClient;

public class BrowserFragment extends Fragment {

    private WebView webView;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        Bundle bundle = this.getArguments();
        String url = bundle.getString("url", "https://www.google.com");

        // Inflate the layout for this fragment
        View rootView = inflater.inflate(R.layout.fragment_browser, container, false);

        webView=(WebView) rootView.findViewById(R.id.webView);
        webView.setWebViewClient(new WebBrowserClient());
        webView.getSettings().setLoadsImagesAutomatically(true);
        webView.getSettings().setJavaScriptEnabled(true);
        webView.setScrollBarStyle(View.SCROLLBARS_INSIDE_OVERLAY);
        webView.loadUrl(url);

        return rootView;
    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
    }

}