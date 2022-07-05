package com.workforcemedicalnetwork.app.ui;

import android.os.Bundle;
import com.workforcemedicalnetwork.app.R;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.FragmentTransaction;
import com.workforcemedicalnetwork.app.utils.Utils;
import com.workforcemedicalnetwork.app.databinding.ActivitySplashBinding;

public class SplashActivity extends AppCompatActivity {
    private ActivitySplashBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        binding = ActivitySplashBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        FragmentTransaction ft = getSupportFragmentManager().beginTransaction();
        ft.replace(R.id.nav_host_fragment_content_splash, new SplashFragment());
        ft.commit();
    }

    @Override
    public void onBackPressed() {
        Utils.AskToExit(this, "Do you want to Logout?");
    }
}