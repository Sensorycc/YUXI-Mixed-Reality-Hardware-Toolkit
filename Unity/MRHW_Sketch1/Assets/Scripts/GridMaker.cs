using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour {

	public GameObject boxGameObject;
	private GameObject tempBox;

	private string testString = "1, 0, 0, 0, 0, 0, 0, 1," +
    					 		"0, 1, 1, 1, 1, 1, 1, 0," +
    					 		"0, 1, 1, 1, 1, 1, 1, 0," +
						 		"0, 1, 1, 0, 0, 1, 1, 0," +
						 		"0, 1, 1, 0, 0, 1, 1, 0," +
						 		"0, 1, 1, 1, 1, 1, 1, 0," +
						 		"0, 1, 1, 1, 1, 1, 1, 0," +
						 		"1, 0, 0, 0, 0, 0, 0, 1";

	// Use this for initialization
	void Start () {
		string[] boxArray  = testString.Split(',');
		for (int i=0; i<boxArray.Length; i++) {
			int tVal = int.Parse(boxArray[i]);
    		Debug.Log(boxArray[i]);	
    		tempBox = Instantiate(boxGameObject, new Vector3(0, Mathf.Ceil(tVal), 0), Quaternion.identity);			
		}
		// foreach(string box in boxArray) {

 	// 	}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
