using UnityEngine;
using System.Collections;

public class SpacebrewEvents : MonoBehaviour {

	SpacebrewClient sbClient;
	bool lightState = false;

/*

Ok, let's do this all in one script?

BaseExample: None?
HelloWorld
	P: None
	S: launchSatellite, string
LightsButtons
	P: buttonPress, boolean
	S: flipLight, boolean
SenseHat
	P: letter, string
	S: direction, string
		up,down,left,right,middle (default)
	S: layer, string

p:2
s:4

 */


	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find ("SpacebrewObject"); // the name of your client object
		sbClient = go.GetComponent <SpacebrewClient> ();

		// register an event with the client and a callback function here.
		// COMMON GOTCHA: THIS MUST MATCH THE NAME VALUE YOU TYPED IN THE EDITOR!!
		sbClient.addEventListener (this.gameObject, "launchSatellite");
		sbClient.addEventListener (this.gameObject, "lightOn");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			print ("Sending Spacebrew Message");
			// name, type, value
			// COMMON GOTCHA: THIS MUST MATCH THE NAME VALUE YOU TYPED IN THE EDITOR!!
			sbClient.sendMessage("buttonPress", "boolean", "true");
		}
		if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
			sbClient.sendMessage("buttonPress", "boolean", "true");
		}
	}

	public void OnSpacebrewEvent(SpacebrewClient.SpacebrewMessage _msg) {


		print ("Received Spacebrew Message");
		print (_msg.name);

		// Look for incoming Satellite messages
		if (_msg.name == "launchSatellite") {
			if (_msg.value == "true") {
				GameObject go = GameObject.Find("BaseBoARd/YourObjectsGoHere/CenterOfUniverse");
				OrbitManager om = go.GetComponent <OrbitManager> ();
				om.makeSatellite();
				print("Tried to launch Satellite");
			}
		}

		// Look for messages to turn the virtual lamp light on
		if (_msg.name == "lightOn") {
			//print(go);
			if (_msg.value == "true") {
				GameObject go = GameObject.Find("BaseBoARd/YourObjectsGoHere/Lamp/SpacebrewSpotlight");
				lightState = !lightState;
				go.gameObject.SetActive(lightState);
			}
		}
		// GameObject go = GameObject.Find ("MatrixContainer"); // the name of your client object
		// MatrixMaker grid = go.GetComponent <MatrixMaker> ();
		// grid.CreateLayer(true);
		// grid.ParseIncomingString(_msg.value);
	}

}
