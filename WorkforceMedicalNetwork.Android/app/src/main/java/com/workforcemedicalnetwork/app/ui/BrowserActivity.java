package com.workforcemedicalnetwork.app.ui;

import android.os.Bundle;
import com.workforcemedicalnetwork.app.R;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.FragmentTransaction;
import com.workforcemedicalnetwork.app.databinding.ActivityBrowserBinding;

public class BrowserActivity extends AppCompatActivity {
    private ActivityBrowserBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        binding = ActivityBrowserBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        Bundle extras = getIntent().getExtras();

        BrowserFragment browserFragment = new BrowserFragment();
        browserFragment.setArguments(extras);

        FragmentTransaction ft = getSupportFragmentManager().beginTransaction();
        ft.replace(R.id.nav_host_fragment_content_browser,  browserFragment);
        ft.commit();
    }
}