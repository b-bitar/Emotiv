using UnityEngine;
using System.Collections;

public class UnpushableCubeScript : MonoBehaviour {
	private GameObject startMarker;
	private GameObject endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	public static bool isMoving = false;
	public static bool moveStarted=false;

	void Start() {
		startMarker = new GameObject ();
		endMarker = new GameObject ();
		startMarker.transform.position = gameObject.transform.position;
		endMarker.transform.position = gameObject.transform.position;
		Debug.Log (startMarker.transform.position);
		endMarker.transform.position = endMarker.transform.position + new Vector3 (5.2f, 0f, -5.2f);
		Debug.Log (startMarker.transform.position);
		journeyLength = Vector3.Distance(startMarker.transform.position, endMarker.transform.position);
	}

	void Update() {
		if (moveStarted) {
			isMoving = true;
		}
		if (isMoving) {
			moveBox ();
		}
	}

	void moveBox(){
		float distCovered;
		if (moveStarted) {
			
			moveStarted = false;
			distCovered = 0; //THE FIX
			startTime = Time.time;
		}else {
			distCovered = (Time.time - startTime) * speed;
		}
		//the push that appears strong in the beginning is due to the fact that fracJourney is starting at 0.2 or 0.3
		//depending on the time taken to perform the above tasks, so the fix is 5 lines above
		//update: the fix didnt work, same problem persists
		float fracJourney = distCovered / journeyLength;
		//Debug.Log (fracJourney);
		//Debug.Log ("in move box:" + startMarker.transform.position);
		transform.position = Vector3.Lerp (startMarker.transform.position, endMarker.transform.position, fracJourney);
		//when it reaches the end of the room, return it to the original position
		if (transform.position == endMarker.transform.position) {
			transform.position = startMarker.transform.position;
			isMoving = false;
		}
	}
}
