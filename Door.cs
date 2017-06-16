using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	protected bool isOpen=false;

	protected float startTime;
	protected float journeyLength;

	protected GameObject originalPosition;
	protected GameObject finalPosition;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void openDoor(){
		GameManagerScript.currentRoom++;
		Debug.Log (GameManagerScript.currentRoom);
		startTime = Time.time;
		//journeyLength = Vector3.Distance (gameObject.transform.position, );
		this.transform.position =finalPosition.transform.position;
	}
}
