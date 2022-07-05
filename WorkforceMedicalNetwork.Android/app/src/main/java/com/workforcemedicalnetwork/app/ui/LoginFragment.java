package com.workforcemedicalnetwork.app.ui;

import java.util.UUID;
import retrofit2.Call;
import android.util.Log;
import android.os.Bundle;
import android.view.View;
import retrofit2.Callback;
import retrofit2.Response;
import android.view.ViewGroup;
import android.widget.Button;
import android.text.Editable;
import android.widget.EditText;
import android.content.Context;
import android.text.TextWatcher;
import android.app.ProgressDialog;
import android.view.LayoutInflater;
import androidx.fragment.app.Fragment;
import com.workforcemedicalnetwork.app.R;
import com.workforcemedicalnetwork.app.Cache;
import com.workforcemedicalnetwork.app.Constants;
import com.workforcemedicalnetwork.app.restapi.APIClient;
import com.workforcemedicalnetwork.app.restapi.ApiInterface;
import com.workforcemedicalnetwork.app.restapi.response.LoginResponse;
import com.workforcemedicalnetwork.app.utils.Utils;

public class LoginFragment extends Fragment {

    Button btnLogin;
    EditText edtPassword, edtEmailAddress;
    LoginResponse loginResponseData;

    public LoginFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        // Inflate the layout for this fragment
        View rootView = inflater.inflate(R.layout.fragment_login, container, false);
        // get button instance
        // get button instance
        btnLogin = (Button) rootView.findViewById(R.id.btn_login);
        edtPassword = (EditText) rootView.findViewById(R.id.edt_password);
        edtEmailAddress = (EditText) rootView.findViewById(R.id.edt_email);
        ValidateEntries();

        // setup now
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                loginApi(getActivity(),
                        edtEmailAddress.getText().toString().trim(),
                        edtPassword.getText().toString().trim()
                );
                edtEmailAddress.setText("");
                edtPassword.setText("");
            }
        });

        edtEmailAddress.addTextChangedListener(new TextWatcher() {
            public void afterTextChanged(Editable s) { ValidateEntries(); }
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {}
            public void onTextChanged(CharSequence s, int start, int before, int count) {}
        });

        edtPassword.addTextChangedListener(new TextWatcher() {
            public void afterTextChanged(Editable s) { ValidateEntries(); }
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {}
            public void onTextChanged(CharSequence s, int start, int before, int count) {}
        });

        // return view back
        return rootView;
    }

    // add code later for quick check look for a @ and a . for now
    private void ValidateEntries()
    {
        String emailAddress = edtEmailAddress.getText().toString();
        String password = edtPassword.getText().toString();
        btnLogin.setEnabled(
            !emailAddress.isEmpty() && emailAddress.contains("@") && emailAddress.contains(".") &&
            !password.isEmpty() && password.length() > 5
        );
    }

    private void loginApi(final Context context, final String emailAddress, String password) {
        Cache.setEmailAddress("");
        Cache.setAuthToken("");

        if(Constants.EnableApi == true) {

            // display a progress dialog
            final ProgressDialog progressDialog = new ProgressDialog(context);
            progressDialog.setCancelable(false);
            progressDialog.setMessage("Please Wait");
            progressDialog.show();

            double latitude = Cache.getGPSTracker().getLatitude();
            double longitude = Cache.getGPSTracker().getLongitude();
            ApiInterface apiService = APIClient.getClient().create(ApiInterface.class);
            Call<LoginResponse> apiCall = apiService.login(
                    emailAddress,
                    password,
                    latitude,
                    longitude
            );
            apiCall.enqueue(new Callback<LoginResponse>() {
                @Override
                public void onResponse(Call<LoginResponse> call, Response<LoginResponse> response) {
                    Log.d("response", response.body().getMessage());
                    loginResponseData = response.body();
                    Cache.setEmailAddress(emailAddress);
                    progressDialog.dismiss();

                    Utils.LoginUser(getContext(), emailAddress,loginResponseData.getUserid());
                }

                @Override
                public void onFailure(Call<LoginResponse> call, Throwable t) {
                    Log.d("response", t.getStackTrace().toString());
                    progressDialog.dismiss();
                }
            });
        } else {
            Utils.LoginUser(getContext(), emailAddress, UUID.randomUUID().toString());
        }
    }
}
