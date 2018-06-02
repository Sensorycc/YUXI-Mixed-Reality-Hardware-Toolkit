using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitManager : MonoBehaviour {
	public Transform satellite;  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void makeSatellite() {
		Instantiate(satellite, new Vector3(Random.value, Random.value, Random.value), Quaternion.identity);
	}
}
