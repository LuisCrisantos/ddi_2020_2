using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;

using System;

public class MotionSensor : MonoBehaviour
{
    public string brokerIpAddress = "192.168.0.113";
	public int brokerPort = 5001;
	public string motionTopic = "casa/patio/movimiento";
    private MqttClient client;
    string lastMessage;
    // Start is called before the first frame update
    void Start()
    {
        client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null);
        string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId);  
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log("ZA WARUDO");
            client.Publish(motionTopic, System.Text.Encoding.UTF8.GetBytes("Rociador activado"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log("KING CRIMSON");
            client.Publish(motionTopic, System.Text.Encoding.UTF8.GetBytes("Rociador desactivado"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
    }

    void OnApplicationQuit()
	{
		client.Disconnect();
	}
}
