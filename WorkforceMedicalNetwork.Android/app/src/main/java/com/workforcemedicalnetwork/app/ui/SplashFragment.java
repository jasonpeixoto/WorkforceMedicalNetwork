package com.workforcemedicalnetwork.app.ui;

import android.view.View;
import android.os.Bundle;
import java.util.ArrayList;
import android.view.ViewGroup;
import android.widget.ListView;
import androidx.annotation.NonNull;
import android.view.LayoutInflater;
import androidx.fragment.app.Fragment;
import com.workforcemedicalnetwork.app.R;
import com.workforcemedicalnetwork.app.Constants;
import com.workforcemedicalnetwork.app.models.ImageData;
import com.workforcemedicalnetwork.app.utils.CustomAdapter;

public class SplashFragment extends Fragment {
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View rootView = inflater.inflate(R.layout.fragment_splash, container, false);

        ArrayList<ImageData> arrayList = Constants.getImageLinks();

        final ListView listView = rootView.findViewById(R.id.image);
        CustomAdapter customAdapter = new CustomAdapter(getContext(), arrayList);
        listView.setAdapter(customAdapter);
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