using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;
using UnityEngine;
using System;

public class TemperatureSensor : MonoBehaviour
{
    public string brokerEndpoint = "test.mosquitto.org";
	public int brokerPort = 1883;
	public string temperatureTopic = "temperature";
    public float temperatureDegrees = 21.7f;
    public bool acState = false;
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

        temperatureDegrees = UnityEngine.Random.Range(9f, 30f);
    
        if((reportTimer += Time.deltaTime) >= reportRate){
            String message = temperatureDegrees.ToString();
            Debug.Log($"Sending report topic: {temperatureTopic}, degrees: {temperatureDegrees}...");
			client.Publish(temperatureTopic, System.Text.Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
			Debug.Log("sent");
            reportTimer=0f;
        }
    }

    public void ToggleState(){
        Debug.Log("SE HIZO EL TOGGLE");
        this.acState = !(this.acState);
    }

	void OnApplicationQuit()
	{
		client.Disconnect();
	}
}
