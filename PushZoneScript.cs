using UnityEngine;
using System.Collections;

public class PushZoneScript : MonoBehaviour {
	public bool playerIsHere;

	// Use this for initialization
	void Start () {
		playerIsHere = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			playerIsHere = true;
		}
	}

	void OnCollisionExit(Collision col){
		if (col.gameObject.tag == "Player") {
			playerIsHere = false;
		}
	}
}
