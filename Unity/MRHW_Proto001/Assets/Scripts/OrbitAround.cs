using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitAround : MonoBehaviour {

	public GameObject centerObject;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Orbit();
	}

	void Orbit() {
		transform.RotateAround(centerObject.transform.position, Vector3.right, speed*Time.deltaTime);
	}

}
