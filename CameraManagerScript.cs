using UnityEngine;
using System.Collections;

public class CameraManagerScript : MonoBehaviour {

	public Camera emotivCamera;
	public Camera playerFirstPersonCamera;

	// Use this for initialization
	void Start () {
		emotivCamera.enabled = false;
//		playerFirstPersonCamera.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.GetKeyDown(KeyCode.P)) {
//			Debug.Log ("Switching cameras");
//			emotivCamera.enabled = !emotivCamera.enabled;
//			playerFirstPersonCamera.enabled = !playerFirstPersonCamera.enabled;
//		}
	}
}
