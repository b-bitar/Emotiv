﻿using UnityEngine;
using System.Collections;

public class RunInstructionsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			Destroy (this.gameObject);
		}
	
	}
}
