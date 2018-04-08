using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 position = new Vector3(-3.0f,0,0.3f);
		this.transform.position = position;
		Debug.Log(position);
		Debug.Log("But actually at: " + this.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
		    Vector3 position = this.transform.position;
		    position.x-=0.1f;
		    this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
		    Vector3 position = this.transform.position;
		    position.x+=0.1f;
		    this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
		    Vector3 position = this.transform.position;
		    position.z+=0.1f;
		    this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
		    Vector3 position = this.transform.position;
		    position.z-=0.1f;
		    this.transform.position = position;
		}
	}
}
