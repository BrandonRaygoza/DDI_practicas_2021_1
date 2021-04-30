using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;

using System;

public class LightSensor : MonoBehaviour
{
    public string brokerEndpoint = "test.mosquitto.org";
	public int brokerPort = 1883;
	public string lightTopic = "light";
    public bool lightState = true;
    public float reportRate = 5f;
    private float reportTimer = 0f;
    private MqttClient client;

    // Use this for initialization
	void Start () {
		// create client instance 
		//client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null); 
		client = new MqttClient(brokerEndpoint, brokerPort, false, null);
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
	}

    void Update ()
    {
        if(!client.IsConnected){
            Debug.LogWarning("No conectado");
            return;
        }

        if((reportTimer += Time.deltaTime) >= reportRate){
            String message = lightState.ToString();
            Debug.Log($"Sending report topic: {lightTopic}, Status: {message}...");
			client.Publish(lightTopic, System.Text.Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
			Debug.Log("sent");
            reportTimer=0f;
        }
    }

    public void ToggleLight(){   /*Cambiar el valor en el sensor, para que este le diga al subscritor que apague o prenda la luz*/
        Debug.Log("SE HIZO EL TOGGLE");
        this.lightState = !(this.lightState);
    }

	void OnApplicationQuit()
	{
		client.Disconnect();
	}
}
