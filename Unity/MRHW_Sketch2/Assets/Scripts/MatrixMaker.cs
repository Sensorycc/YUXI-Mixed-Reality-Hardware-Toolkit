using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*



*/

public class MatrixMaker : MonoBehaviour {

	public GameObject gridObject;
	List<GameObject> gridLayers = new List<GameObject>();
	private GameObject container;
	private GameObject containerObject;
	private int numberLayers;
	private string [] pixelArray;
	private string testString = "0 0 1 1 1 0 0 0 0 1 1 1 1 1 0 0 1 1 1 1 1 1 1 0 1 1 1 1 1 1 1 0 1 1 1 1 1 1 1 0 0 1 1 1 1 1 0 0 0 0 1 1 1 0 0 0 0 0 0 0 0 0 0 0";

	public class GridLayer : MonoBehaviour {
		List<GridObject> layerObjects = new List<GridObject>();
		private int rows, cols;
		public bool hasAnimated;
		public bool isAnimating;
		public Vector3 myPos;
		private string [] incomingGrid;

		public GridLayer() {
			
		}

		public void Initialize(int _layerNumber, GameObject _container, GameObject _gridObject, int _rows, int _cols) {
			hasAnimated = false;
			isAnimating = false;
			//Debug.Log("Going to make a grid");
			float spacing = 0.2f;
			float gridSize = 1.0f;
			Vector3 scale = new Vector3(0.8f, 0.8f, 0.8f);
			for (int i=0; i<_rows; i++) {
    			for (int j=0; j<_cols; j++) {
    				Vector3 tPos = transform.parent.localPosition + new Vector3((i*gridSize)+spacing, 0, (j*gridSize)+spacing);
    				bool tVal;
    				if (int.Parse(incomingGrid[(i*_rows)+j]) == 0) {
    					tVal = false;
    				} else {
    					tVal = true;
    				}

    				print ("THE CUBE VALUE IS: "+int.Parse(incomingGrid[(i*j)+j])+" : "+tVal);
    				//tVal = 1;
    				GridObject tGO = new GridObject(_container, _gridObject, tPos, scale, tVal);
    				layerObjects.Add(tGO);
    			}
    		}
		}

		public void setGrid(string[] _inc) {
			incomingGrid = _inc;
		}

		public void ToggleAnimation() {
			isAnimating = !isAnimating;
		}

		public void Update(){
			//Debug.Log("BUT IS REALLY: " +transform.localPosition);
			//Vector3 tVec = new Vector3(-2.2f, transform.localPosition.y, -0.2f);
			//transform.localPosition = tVec;
			if (isAnimating == true) {
				transform.localPosition += new Vector3(0, 0.1f, 0);
			}
		}
	}

	public class GridObject {
		public GridObject(GameObject _container, GameObject _gridObject, Vector3 _objPos, Vector3 _objScale, bool _isVisible) {
			
			GameObject tempBox = Instantiate(_gridObject); //, _objPos, Quaternion.identity);
			//Debug.Log("ZZZZZZZZ: "+ tempBox);
			tempBox.transform.parent = _container.transform; 
			tempBox.transform.localPosition = _objPos;
			tempBox.transform.localScale = _objScale;	

			if (_isVisible == false) {
				//tempBox.renderer.enabled = false;
				 tempBox.gameObject.SetActive(false);
			}

			//Debug.Log("Made a gridObject: " + _gridObject);
		}
	}


	// Use this for initialization
	void Start () {
		
		numberLayers = 0;
		ParseIncomingString(testString);
		container = gameObject;
		CreateLayer(false); // Create one to start alignment and don't animate until we start getting spacebrew messages

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			CreateLayer(true);
			print ("Creating Layer");
		}

		foreach (GameObject layer in gridLayers) {
			GridLayer cO = layer.GetComponent(typeof(GridLayer)) as GridLayer;
			//cO.Initialize(layerCount);
			//Debug.Log(layerCount);
			if (layer.transform.localScale.y < 1.0f) {
				layer.transform.localScale += new Vector3(0, 0.1f, 0);
			} else {
				cO.hasAnimated = true;
			}
		}
	}

	public void CreateLayer(bool _isAnimated) {
		// Create the layer 
		containerObject = new GameObject("layer" + numberLayers);
		//print("THERE ARE: " + numberLayers + " LAYERS.");

		// Set the initial conditions for the layer
		containerObject.transform.parent = container.transform;
		containerObject.transform.position = container.transform.position;

		// Set the exact offset location
		containerObject.transform.localPosition = new Vector3(-1.0f,0,0.2f);;

		//Debug.Log("Called from this object: " +containerObject);
		//containerObject.transform.localPosition = new Vector3(-2.0f,0,0.2f);

		containerObject.gameObject.AddComponent<GridLayer>();
		GridLayer cO = containerObject.GetComponent(typeof(GridLayer)) as GridLayer;
		cO.setGrid(pixelArray);
		cO.Initialize(numberLayers,containerObject,gridObject,8,8);
		if (_isAnimated == true) {
			cO.isAnimating = true;
		} else {
			cO.isAnimating = false;
		}
		
		// Add the layer to a list
		//GridLayer tG = new GridLayer();
		//tG.Initialize(containerObject,gridObject,8,8);
		gridLayers.Add(containerObject);
		numberLayers++; // Keep track of how many layers we have made
	}

	public void ParseIncomingString(string _val) {
		pixelArray = _val.Split(' '); 
		print("THE CUURENT PIXELARRAY IS: "+pixelArray);
		print("THE CURRENT LENGTH IS: "+pixelArray.Length);
		// loop through and make into 1 or 0
		for (int x=0; x<pixelArray.Length; x++) {
			print("THE CURRENT ARRAY IS: "+pixelArray[x]);
		}
		// 	if (pixelArray[x] == "0") {
		// 		pixelArray[x] = "0";
		// 	} else {
		// 		pixelArray[x] = "1";
		// 	}
		// }
		//print("DEFAULT STRING SENT, IT SHOULD WORK");
		//incomingGrid = pixelArray;
	}
}
