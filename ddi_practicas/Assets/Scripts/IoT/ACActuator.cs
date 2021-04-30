using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;

using System;

public class ACActuator : MonoBehaviour
{
    /*Parametros para establecer conexion*/
    public string brokerEndpoint = "test.mosquitto.org";
	public int brokerPort = 1883;
	public string temperatureTopic = "temperature";
    public string lightTopic = "light";

    /*Para mi beneficio*/
    public float temperatureThreshold = 22f;
    string lastMessage;
    bool updateDegrees = false;

    /*Referencia a GameObjects*/
    public Text acStatusText;
    public Text acDegreesText;
    public Text lightStatusText;
    public Light spotLight;

    private MqttClient client;

    //public GameObject aireAcondicionado;
    volatile bool acState = false;
    volatile bool lightState = false;
   
    // Use this for initialization
	void Start () 
    {
		// create client instance 
		client = new MqttClient(brokerEndpoint, brokerPort, false, null);
        
        // register to message received 
		client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; 
		
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 

        // subscribe to the topic "/home/temperature" with QoS 2 
		client.Subscribe(new string[] { temperatureTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
		client.Subscribe(new string[] { lightTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
	}

    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);

        if(e.Topic.Equals(lightTopic)){
            if(lastMessage.Equals("False")){
                lightState = false;
            }else if(lastMessage.Equals("True")){
                lightState = true;
            }
        }

        if(e.Topic.Equals(temperatureTopic)){
            float temp;
            float.TryParse(lastMessage, out temp);
            if(temp > temperatureThreshold){
                acState = true;
            }else{
                acState = false;
            }
            updateDegrees = true;
        }
	}

    // Update is called once per frame
    void Update()
    {
        if(lightState == true){
            lightStatusText.text = "ON";
        }else if(lightState == false){
            lightStatusText.text = "OFF";
        }            
		spotLight.enabled = lightState;

        if(acState){
            acStatusText.text = "ON";
        }
        else{
            acStatusText.text = "OFF";
        }

        if(updateDegrees){
             acDegreesText.text = lastMessage;
             updateDegrees = false;
        }
    }
}
