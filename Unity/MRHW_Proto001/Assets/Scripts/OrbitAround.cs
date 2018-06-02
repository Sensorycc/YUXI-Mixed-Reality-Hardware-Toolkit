using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAround : MonoBehaviour {

	public GameObject centerObject;
	public float speed;
	private bool orb1, orb2, orb3;

	// Use this for initialization
	void Start () {
		if (Random.value > 0.5f) {
			orb1 = true;
		} else {
			orb1 = false;
			orb3 = true;
		}

		if (Random.value > 0.5f) {
			orb2 = true;
		} else {
			orb2 = false;
		}

		if (Random.value > 0.5f) {
			orb3 = true;
		} else {
			orb3 = false;
		}

		if (orb1 == false && orb2 == false && orb3 == false) {
			orb3 = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Orbit();
	}

	void Orbit() {
		if (orb1 == true) {
			transform.RotateAround(centerObject.transform.position, Vector3.right, speed*Time.deltaTime);
		}
		if (orb2 == true) {
			transform.RotateAround(centerObject.transform.position, Vector3.up, speed*Time.deltaTime);
		}
		if (orb3 == true) {
			transform.RotateAround(centerObject.transform.position, Vector3.back, speed*Time.deltaTime);
		}
	}

}
