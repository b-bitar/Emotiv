using UnityEngine;
using System.Collections;

public class JumpInstructionsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Destroy (this.gameObject);
		}
	
	}
}
