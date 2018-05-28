using UnityEngine;
using System.Collections;

public class SpacebrewEvents : MonoBehaviour {

	SpacebrewClient sbClient;
	bool lightState = false;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find ("SpacebrewObject"); // the name of your client object
		sbClient = go.GetComponent <SpacebrewClient> ();

		// register an event with the client and a callback function here.
		// COMMON GOTCHA: THIS MUST MATCH THE NAME VALUE YOU TYPED IN THE EDITOR!!
		sbClient.addEventListener (this.gameObject, "layer");
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
		print (_msg.value);
		GameObject go = GameObject.Find("BaseBoARd/Lamp/SpacebrewSpotlight");
		print(go);
		if (_msg.value == "true") {
			lightState = !lightState;
			go.gameObject.SetActive(lightState);
		}
		// GameObject go = GameObject.Find ("MatrixContainer"); // the name of your client object
		// MatrixMaker grid = go.GetComponent <MatrixMaker> ();
		// grid.CreateLayer(true);
		// grid.ParseIncomingString(_msg.value);
	}

}
