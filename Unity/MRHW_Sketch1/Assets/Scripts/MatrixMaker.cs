using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixMaker : MonoBehaviour {

	public GameObject gridObject;
	List<GameObject> gridLayers = new List<GameObject>();
	private GameObject container;
	public GameObject containerObject;
	private int numberLayers;

	public class GridLayer : MonoBehaviour {
		List<GridObject> layerObjects = new List<GridObject>();
		private int rows, cols;
		public bool hasAnimated;
		public bool isAnimating;
		public Vector3 myPos;

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
    				Vector3 tPos = new Vector3((i*gridSize)+spacing, 0, (j*gridSize)+spacing);
    				GridObject tGO = new GridObject(_container, _gridObject, tPos, scale);
    				layerObjects.Add(tGO);
    			}
    		}
		}

		public void ToggleAnimation() {
			isAnimating = !isAnimating;
		}

		public void Update(){
			if (isAnimating == true) {
				transform.localPosition += new Vector3(0, 0.1f, 0);
			}
		}
	}

	public class GridObject {
		public GridObject(GameObject _container, GameObject _gridObject, Vector3 _objPos, Vector3 _objScale) {
			
			GameObject tempBox = Instantiate(_gridObject, _objPos, Quaternion.identity);
			tempBox.transform.localScale = _objScale;	
			tempBox.transform.parent = _container.transform; 
			//Debug.Log("Made a gridObject: " + _gridObject);
		}
	}


	// Use this for initialization
	void Start () {
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

		// Set the initial conditions for the layer
		containerObject.transform.parent = container.transform;
		containerObject.gameObject.AddComponent<GridLayer>();
		GridLayer cO = containerObject.GetComponent(typeof(GridLayer)) as GridLayer;
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
}
