package com.workforcemedicalnetwork.app.ui;

import android.view.View;
import java.util.UUID;
import retrofit2.Call;
import android.util.Log;
import android.os.Bundle;
import retrofit2.Callback;
import retrofit2.Response;
import android.widget.Button;
import android.text.Editable;
import android.view.ViewGroup;
import android.widget.EditText;
import android.content.Context;
import android.text.TextWatcher;
import android.app.ProgressDialog;
import android.view.LayoutInflater;
import android.widget.Toast;

import androidx.fragment.app.Fragment;

import com.workforcemedicalnetwork.app.Cache;
import com.workforcemedicalnetwork.app.R;
import com.workforcemedicalnetwork.app.Constants;
import com.workforcemedicalnetwork.app.restapi.APIClient;
import com.workforcemedicalnetwork.app.restapi.ApiInterface;
import com.workforcemedicalnetwork.app.restapi.Request.RegistrationRequest;
import com.workforcemedicalnetwork.app.restapi.response.RegisterResponse;
import com.workforcemedicalnetwork.app.utils.Utils;

public class RegisterFragment extends Fragment {

    Button btnRegister;
    EditText edtPassword, edtPasswordRepeat, edtFullName, edtEmailAddress;
    RegisterResponse registerResponseData;


    public RegisterFragment() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_register, container, false);

        btnRegister = (Button) rootView.findViewById(R.id.btn_register);
        edtPassword = (EditText) rootView.findViewById(R.id.edt_password);
        edtPasswordRepeat = (EditText) rootView.findViewById(R.id.edt_repassword);
        edtEmailAddress = (EditText) rootView.findViewById(R.id.edt_email);
        edtFullName = (EditText) rootView.findViewById(R.id.edt_name);

        ValidateEntries();

        // setup now
        btnRegister.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                registerApi(getActivity(),
                        edtFullName.getText().toString().trim(),
                        edtEmailAddress.getText().toString().trim(),
                        edtPassword.getText().toString().trim()
                );
            }
        });

        edtFullName.addTextChangedListener(new TextWatcher() {
            public void afterTextChanged(Editable s) { ValidateEntries(); }
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {}
            public void onTextChanged(CharSequence s, int start, int before, int count) {}
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

        edtPasswordRepeat.addTextChangedListener(new TextWatcher() {
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
        String fullName = edtFullName.getText().toString();
        String emailAddress = edtEmailAddress.getText().toString();
        String password = edtPassword.getText().toString();
        String passwordRepeat = edtPasswordRepeat.getText().toString();
        boolean enabled =
                (!emailAddress.isEmpty() && emailAddress.contains("@") && emailAddress.contains(".")) &&
                (!password.isEmpty() && (password.length() > 5)) &&
                (!passwordRepeat.isEmpty()  && passwordRepeat.length() > 5) &&
                (password.equals(passwordRepeat)) &&
                (!fullName.isEmpty());
        btnRegister.setEnabled(enabled);
    }

    private void registerApi(final Context context, String fullName, final String emailAddress, String password) {
        // display a progress dialog
        if(Constants.EnableApi == true) {

            final ProgressDialog progressDialog = new ProgressDialog(context);
            progressDialog.setCancelable(false);
            progressDialog.setMessage("Please Wait");
            progressDialog.show();

            RegistrationRequest request = new RegistrationRequest();
            request.Create(
                    fullName,
                    emailAddress,
                    password,
                    Utils.GetCurrentDateTime(),
                    Cache.getGPSTracker().getLatitude(),
                    Cache.getGPSTracker().getLongitude()
            );

            ApiInterface apiService = APIClient.getClient().create(ApiInterface.class);
            Call<RegisterResponse> apiCall = apiService.registration(request);
            apiCall.enqueue(new Callback<RegisterResponse>() {
                @Override
                public void onResponse(Call<RegisterResponse> call, Response<RegisterResponse> response) {
                    //Log.d("response", response.body().toString());
                    registerResponseData = response.body();
                    progressDialog.dismiss();
                    if(registerResponseData.getAuthenticated()) {
                        Utils.LoginUser(getContext(), emailAddress, registerResponseData.getToken());
                    } else {
                        Toast.makeText(context, "Failed to register", Toast.LENGTH_SHORT).show();
                    }
                }

                @Override
                public void onFailure(Call<RegisterResponse> call, Throwable t) {
                    //Log.d("response", t.getStackTrace().toString());
                    progressDialog.dismiss();
                }
            });
        } else {
            Utils.LoginUser(getContext(), emailAddress, UUID.randomUUID().toString());
        }
    }
}
