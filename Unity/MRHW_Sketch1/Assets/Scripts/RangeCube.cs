using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public GameObject prefab;
	public GameObject cubeparent;
	private GameObject item;
	private bool spawned = false;
	//private static GameObject cubeContainer;

	// Update is called once per frame
	void Update () {
		// Use spacebrew to set the height from a range value
		
		// if the object is not above a certain place then animate up


    	//if (Input.GetKeyDown(KeyCode.Space)) {
		if (spawned == false) {
			Debug.Log("spawned");
    		GameObject tO = cubeparent;
        	item = GameObject.Instantiate(prefab) as GameObject;
        	item.transform.parent = tO.transform;
        	item.transform.localPosition = new Vector3(0, 0, 0);
        	item.transform.localScale = new Vector3(1, 1, 1);
        	spawned = true;
        }
        	//cubeContainer.transform.parent = GameObject.Find("HandMadeCube").transform;
    	//}

        if (spawned == true) {
        	Debug.Log("Animating");
        	Debug.Log(item.transform.position.y);
			if (item.transform.position.y < 0.1f)	{
				//item.transform.localPosition += new Vector3(0.0f, 0.005f, 0.0f);
				Vector3 position = item.transform.position;
			    position.y+=0.001f;
			    item.transform.position = position;
			} else {
				item.transform.localPosition = new Vector3(0,0,0);
				Vector3 position = item.transform.position;
			    position.y=0.0f;
			    item.transform.position = position;
			}
		}

	    // Create a 
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
		    Vector3 position = this.transform.position;
		    position.x-=0.01f;
		    this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
		    Vector3 position = this.transform.position;
		    position.x+=0.01f;
		    this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
		    Vector3 position = this.transform.position;
		    position.z+=0.01f;
		    this.transform.position = position;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
		    Vector3 position = this.transform.position;
		    position.z-=0.01f;
		    this.transform.position = position;
		}
	}
}
