spacebrewUnity
==============

A Spacebrew client library for Unity3D. 

Usage: This is a unitypackage which can be imported into your Unity project. Drag the Spacebrew prefab contained within the Spacebrew folder into your project hierarchy. This contains two scripts:

SpacebrewClient: This is where you configure your Spacebrew client to point to your desired server and setup your publishers and subscribers.

![Alt text](/screenshots/Capture.PNG "Spacebrew Client")

SpacebrewEvents: This is what you attach to your game object to have it send and receive Spacebrew events.


	SpacebrewClient sbClient;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find ("SpacebrewObject"); // the name of your client object
		sbClient = go.GetComponent <SpacebrewClient> ();

		// register an event with the client and a callback function here.
		// COMMON GOTCHA: THIS MUST MATCH THE NAME VALUE YOU TYPED IN THE EDITOR!!
		sbClient.addEventListener (this.gameObject, "mystring");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			print ("Sending Spacebrew Message");
			// name, type, value
			// COMMON GOTCHA: THIS MUST MATCH THE NAME VALUE YOU TYPED IN THE EDITOR!!
			sbClient.sendMessage("mybool", "boolean", "true");
		}
	}

	public void OnSpacebrewEvent(SpacebrewClient.SpacebrewMessage _msg) {
		print ("Received Spacebrew Message");
		print (_msg.name);
		print (_msg.value);
	}


