package com.workforcemedicalnetwork.app.ui;

import android.Manifest;
import android.os.Bundle;
import android.content.Intent;
import androidx.fragment.app.Fragment;
import androidx.core.app.ActivityCompat;
import android.content.pm.PackageManager;
import com.workforcemedicalnetwork.app.R;
import androidx.viewpager.widget.ViewPager;
import androidx.core.content.ContextCompat;
import androidx.fragment.app.FragmentManager;
import com.workforcemedicalnetwork.app.Cache;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.FragmentPagerAdapter;
import com.workforcemedicalnetwork.app.gps.GPSTracker;
import com.workforcemedicalnetwork.app.gps.GpsService;
import com.workforcemedicalnetwork.app.mqtt.MqttClient;
import com.workforcemedicalnetwork.app.utils.Utils;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    private ViewPager viewPager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        if (ContextCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            ActivityCompat.requestPermissions(this,new String[] { Manifest.permission.ACCESS_FINE_LOCATION }, 1);
        }
        if (ContextCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            ActivityCompat.requestPermissions(this,new String[] { Manifest.permission.ACCESS_COARSE_LOCATION }, 1);
        }

        // setup gps here
        Cache.setGPSTracker(new GPSTracker(this));
        Cache.setMainActivity(this);

        // setup mqtt here
        Cache.setMqttAndroidClient(new MqttClient());
        Cache.getMqttAndroidClient().Create(this);

        // Check if GPS enabled if not show popup
        if(!Cache.getGPSTracker().canGetLocation()) {
            Cache.getGPSTracker().showSettingsAlert();
        }

        startService(new Intent(this, GpsService.class));

        viewPager = findViewById(R.id.viewPager);
        LoginAdaptor();
    }

    @Override
    public void onBackPressed() {
        Utils.AskToExit(this, "Do you want to Exit?");
    }

    public void LoginAdaptor()
    {
        AuthenticationPagerAdapter pagerAdapter = new AuthenticationPagerAdapter(getSupportFragmentManager());
        pagerAdapter.addFragmet(new LoginFragment());
        pagerAdapter.addFragmet(new RegisterFragment());
        viewPager.removeAllViews();
        viewPager.setAdapter(pagerAdapter);
    }

    static class AuthenticationPagerAdapter extends FragmentPagerAdapter {
        private ArrayList<Fragment> fragmentList = new ArrayList<>();

        public AuthenticationPagerAdapter(FragmentManager fm) {
            super(fm);
        }

        @Override
        public Fragment getItem(int i) {
            return fragmentList.get(i);
        }

        @Override
        public int getCount() {
            return fragmentList.size();
        }

        void addFragmet(Fragment fragment) {
            fragmentList.add(fragment);
        }
    }
}
