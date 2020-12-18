using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class DashboardClient : MonoBehaviour {
	public string brokerIpAddress = "192.168.0.113";
	public int brokerPort = 5001;
	public string temperatureTopic = "casa/sala/temperatura";
	public string gardenTopic = "casa/patio/rociadores";
	public List <GameObject> fonts = new List <GameObject>();
	int i = 0;
	private MqttClient client;
	public Text displayText;
	public Text displayActive;
	string lastMessage;
    string temperature = "0";
	string rociadores = "Activado";
	// Use this for initialization
	void Start () {
		// create client instance 
		client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null); 
		
		// register to message received 
		client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; 
		
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
		
		client.Subscribe(new string[] { temperatureTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
		client.Subscribe(new string[] { gardenTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
	}
	
	void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
		
        if(e.Topic.Equals(temperatureTopic))
        {
            temperature = lastMessage;
        }
		if(e.Topic.Equals(gardenTopic))
        {
            rociadores = lastMessage;
        }
	}

	void Update()
	{
		displayText.text = temperature + " °C";
		displayActive.text = rociadores;

		if(lastMessage.Equals("Desactivado"))
		{
			fonts[0].transform.position = new Vector3(0,-3f,0);
			fonts[1].transform.position = new Vector3(0,-3f,0);
			fonts[2].transform.position = new Vector3(0,-3f,0);
		}
		else if(lastMessage.Equals("Activado"))
		{
			fonts[0].transform.position = new Vector3(7.68f,-0.18f,-13.81f);
			fonts[1].transform.position = new Vector3(13.26f,-0.18f,-8.37f);
			fonts[2].transform.position = new Vector3(1.03f,-0.18f,-3.11f);
		}
	}

	void OnApplicationQuit()
	{
		client.Disconnect();
	}
}
