using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelSpheroid : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for (int i=0; i<8; i++)
			for (int j=0; j<8; j++)
				for(int k=0; k<8; k++)
					VoxelTools.MakeCube(i, j+5, k, Color.cyan, 0.01f);
					print("Made cube");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			VoxelTools.MakeAllCubesFall();
		}
		
	}
}
