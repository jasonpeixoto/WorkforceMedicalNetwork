package com.workforcemedicalnetwork.app.mqtt;

import android.content.Context;
import com.workforcemedicalnetwork.app.Constants;
import org.eclipse.paho.android.service.MqttAndroidClient;
import org.eclipse.paho.client.mqttv3.IMqttActionListener;
import org.eclipse.paho.client.mqttv3.IMqttDeliveryToken;
import org.eclipse.paho.client.mqttv3.IMqttToken;
import org.eclipse.paho.client.mqttv3.MqttCallback;
import org.eclipse.paho.client.mqttv3.MqttException;
import org.eclipse.paho.client.mqttv3.MqttMessage;

public class MqttClient {

    private Context context;
    private String clientId;
    private MqttAndroidClient client;

    public MqttClient Create(Context context)
    {
        this.context = context;
        if(Constants.EnableMqtt == false) return null;
        clientId = org.eclipse.paho.client.mqttv3.MqttClient.generateClientId();
        client = new MqttAndroidClient(context.getApplicationContext(), Constants.MqttUrl, clientId);

        try {
            IMqttToken token = client.connect();
            ((IMqttToken) token).setActionCallback(new IMqttActionListener() {
                @Override
                public void onSuccess(IMqttToken asyncActionToken) {
                    //
                }

                @Override
                public void onFailure(IMqttToken asyncActionToken, Throwable exception) {
                    //
                }
            });
        } catch (MqttException e) {
            e.printStackTrace();
        }

        // setup callback here
        client.setCallback(new MqttCallback() {
            @Override
            public void connectionLost(Throwable cause) {
            }

            @Override
            public void messageArrived(String topic, MqttMessage message) throws Exception {
                // broadcast message here
            }
            @Override
            public void deliveryComplete(IMqttDeliveryToken token) {

            }
        });
        return this;
    }

    public IMqttToken Publish(String topic, String message) throws MqttException {
        if(Constants.EnableMqtt == false) return null;
        return client.publish(topic, message.getBytes(),0,false);
    }
}
