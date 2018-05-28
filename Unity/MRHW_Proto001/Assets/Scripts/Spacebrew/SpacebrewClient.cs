using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using SimpleJSON;
using System;
using System.Reflection;

public class SpacebrewClient : MonoBehaviour {

	[Serializable]
	public class Publisher
		{
			public string name;
			public enum type{
				BOOLEAN = 0,
				STRING = 1,
				RANGE = 2
			};
			public type pubType;
			//public string defaultValue;
		}

	[Serializable]
	public class Subscriber
	{
		public string name;
		public enum type{
			BOOLEAN = 0,
			STRING = 1,
			RANGE = 2
		};
		public type subType;
	}

	public class SpacebrewMessage
	{
		public string name;
		public string type;
		public string value;
		public string clientName;
	}

	public class SpacebrewEvent
	{
		public GameObject sbGo;
		public string sbEvent;
	}

	public WebSocket conn;
	public string serverAddress; // you can include the port number so ws://192.168.7.2:9000
	public Publisher[] publishers;
	public Subscriber[] subscribers;
	public string clientName;
	public string descriptionText;
	public ArrayList SpacebrewEvents;
	List<SpacebrewEvent> spacebrewEvents = new List<SpacebrewEvent>();
	List<SpacebrewMessage> spacebrewMsgs = new List<SpacebrewMessage>();

	void Awake() {
		conn = new WebSocket (serverAddress); // removed WebSocket on begin
		conn.OnOpen += (sender, e) => {
						print ("Attempting to open socket");
				};

		conn.OnMessage += (sender, e) => {
			print (e.Data);

			// parse the incoming json message from spacebrew
			var N = JSON.Parse(e.Data);
			var cMsg = new SpacebrewMessage();
			cMsg.name = N["message"]["name"];
			cMsg.type = N["message"]["type"];
			cMsg.value = N["message"]["value"];
			cMsg.clientName = N["message"]["clientName"];
		
			print (cMsg);
			spacebrewMsgs.Add(cMsg);
			//ProcessSpacebrewMessage(cMsg);

//			if (e.Type == Opcode.Text) {
//				// Do something with e.Data
//				print (e);
//				print (e.Data);
//				return;
//			}
//			
//			if (e.Type == Opcode.Binary) {
//				// Do something with e.RawData
//				return;
//			}

		};

		conn.OnError += (sender, e) => {
			print ("THERE WAS AN ERROR CONNECTING");
			print (e.Message);
		};

		conn.OnClose += (sender, e) => {
			print ("Connection closed");
		};

		print ("Attemping to connect to " + serverAddress);
		conn.Connect ();

		//addPublisher ("power", "boolean", "0");
		//addSubscriber ("hits", "boolean");

		// Connect and send the configuration for the app to Spacebrew
		conn.Send (makeConfig().ToString());
	}

	// You can use these to programatically add publisher and subsribers
	// otherwise you should do it through the editor interface.
	void addPublisher(string _name, string _type, string _default) {
		var P = new JSONClass();
		P ["name"] = _name;
		P ["type"] = _type;
//		if (_default != "") {
//			P ["default"] = _default;
//		}
		//publishers.Add(P);
	}
	
	void addSubscriber(string _name, string _type) {
		var S = new JSONClass();
		S ["name"] = _name;
		S ["type"] = _type;
		//subscribers.Add(S);
	}
	
	private JSONClass makeConfig() {
		// Begin the JSON config
		var I = new JSONClass();
		I["name"] = clientName;
		I["description"] = descriptionText;
		
		// Add all the publishers
		print ("there are " + publishers.Length);
		for (int i = 0; i < publishers.Length; i++) // Loop through List with for
		{
			var O = new JSONClass();
			O["name"] = publishers[i].name;
			string tType = "empty";
			switch ((int)publishers[i].pubType) {
			case 0:
				tType = "boolean";
				break;
			case 1:
				tType = "string";
				break;
			case 2:
				tType = "range";
				break;
			}
			O["type"] = tType;
			O["default"] = "";
			I["publish"] ["messages"][-1] = O;
		}
		
		// Add all the subscribers
		for (int i = 0; i < subscribers.Length; i++) // Loop through List with for
		{
			var Q = new JSONClass();
			Q["name"] = subscribers[i].name;
			string tType = "empty";
			switch ((int)subscribers[i].subType) {
			case 0:
				tType = "boolean";
				break;
			case 1:
				tType = "string";
				break;
			case 2:
				tType = "range";
				break;
			}
			Q["type"] = tType;
			I["subscribe"] ["messages"][-1] = Q;
		}

		
		// Add everything to config
		var C = new JSONClass();
		C ["config"] = I;
		
		print("Connection:");
		print(C.ToString());
		print("");
		
		return C;
	}
	
	void onOpen() {
		
	}
	
	void onClose() {
		
	}

	public void addEventListener(GameObject _sbGo, string _event) {
		print ("Adding a listener for " + _event);
		SpacebrewEvent evt = new SpacebrewEvent();
		evt.sbGo = _sbGo;
		evt.sbEvent = _event;
		spacebrewEvents.Add(evt);
	}

	public void sendMessage(string _name, string _type, string _value) {
		var M = new JSONClass();
		M["clientName"] = clientName;
		M["name"] = _name;
		M["type"] = _type;
		M["value"] = _value;

		var MS = new JSONClass ();
		MS ["message"] = M;
		conn.Send(MS.ToString());
		//        conn.Send (makeConfig().ToString());
		
		//       {
		//         "message":{
		//           "clientName":"CLIENT NAME (Must match the name in the config statement)",
		//           "name":"PUBLISHER NAME (outgoing messages), SUBSCRIBER NAME (incoming messages)",
		//           "type":"DATA TYPE",
		//           "value":"VALUE",
		//       }
		//   }
		
	}

	void ProcessSpacebrewMessage(SpacebrewMessage _cMsg) {
//		foreach (SpacebrewEvent element in spacebrewEvents)
//		{
//			//This will now work because you've constrained the generic type V
//			print(element.sbEvent);
//			if (_cMsg.name == element.sbEvent) {
//
//				// if this element subscribes to this event then call it's callback
//				//element.eventCallback
//				//element.sbGo.OnSpacebrewEvent(_cMsg);
//				element.sbGo.SendMessage("OnSpacebrewEvent", _cMsg);
//				//this.GetComponent<SpacebrewEvents>().OnSpacebrewEvent(_cMsg);
//				//this.GetComponent<MyScript>().MyFunction();
//				//print(element.sbGo);
//				//element.sbGo.gameObject.SpacebrewEvent(_cMsg);
//				//element.sbGo.
////				MethodInfo mi = element.sbGo.GetType().GetMethod(element.eventCallback);
//				//mi.Invoke(element.sbGo, null);
//			}
//		}
		if (_cMsg.name == "hits") {
			if (_cMsg.value == "true"){
				print ("do something");
					//pillVisible = !pillVisible;
				}
			}		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// go through new messages
		foreach (SpacebrewMessage element in spacebrewMsgs)
		{
			//This will now work because you've constrained the generic type V
			//print(element.sbEvent);
			//if (_cMsg.name == element.sbEvent) {
				
				// if this element subscribes to this event then call it's callback
				//element.eventCallback
				//element.sbGo.OnSpacebrewEvent(_cMsg);
				//element.sbGo.SendMessage("OnSpacebrewEvent", _cMsg);
				this.GetComponent<SpacebrewEvents>().OnSpacebrewEvent(element);
				//this.GetComponent<MyScript>().MyFunction();
				//print(element.sbGo);
				//element.sbGo.gameObject.SpacebrewEvent(_cMsg);
				//element.sbGo.
				//				MethodInfo mi = element.sbGo.GetType().GetMethod(element.eventCallback);
				//mi.Invoke(element.sbGo, null);
			//}
		}
		spacebrewMsgs.Clear();

		if (Input.GetKeyDown ("space")) {
			print ("Sending Spacebrew Message");
			//sendMessage();
		}
		//GameObject.Find("pill").renderer.enabled = pillVisible;
	}
}
		
