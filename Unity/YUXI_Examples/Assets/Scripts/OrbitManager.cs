using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitManager : MonoBehaviour {
	public GameObject satellite;  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void makeSatellite() {
		GameObject go = Instantiate(satellite, new Vector3(Random.value, Random.value, Random.value), Quaternion.identity) as GameObject;
		GameObject CenterOfUniverse = GameObject.Find("BaseBoARd/YourObjectsGoHere"); 
		go.transform.SetParent(CenterOfUniverse.transform, false);
 		//go.transform.parent = CenterOfUniverse.transform;
		//go.transform.scale = go.transform.scale * 100; 
		print("Launched Satellite");
	}
}
