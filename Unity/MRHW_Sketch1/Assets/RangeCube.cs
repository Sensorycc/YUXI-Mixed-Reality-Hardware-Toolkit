using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Use spacebrew to set the height from a range value
		transform.localScale += new Vector3(0.0f, 0.005f, 0.0f);
	}
}
