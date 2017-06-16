using UnityEngine;
using System.Collections;

public class TestCubeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<MeshRenderer>().materials[0].color = Color.red;
	}
	
	// Update is called once per frame
	void Update ()
	{/*
		if (Input.GetKeyDown (KeyCode.R)) {
			gameObject.GetComponent<MeshRenderer>().materials[0].color = Color.red;
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			makeBlue ();
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			gameObject.GetComponent<MeshRenderer>().materials[0].color = Color.white;
		}
		*/
	}

	void makeBlue(){
		gameObject.GetComponent<MeshRenderer> ().materials [0].color = Color.blue;
	}
}