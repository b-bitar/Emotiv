using UnityEngine;
using System.Collections;

public class StaringScript : MonoBehaviour {
	private Vector3 cameraLocation;
	private Vector3 cameraDirection;
	public float lineOfSight = 30f;
	bool watching=false;
	//int blinkCount=0;

	float watchTimer = 0f;
	//public GUIText blinkedText;
	public GameObject blinkedText;

	void Start () {
		//EmoState es;
	}
		
	void Update () {
		RaycastHit hit;
		cameraLocation = GetComponentInChildren<Camera> ().transform.position;
		cameraDirection = GetComponentInChildren<Camera>().transform.TransformDirection (Vector3.forward);
		Ray visionRay = new Ray (cameraLocation,cameraDirection);

		Debug.DrawRay (cameraLocation,cameraDirection * 15);

		if (Physics.Raycast (visionRay, out hit, lineOfSight)) {
			//if the object is a picture and it hasn't been completed yet
			if (hit.collider.tag == "StareTarget"){// && hit.collider.gameObject.GetComponent<MeshRenderer> ().materials [0].color == Color.red) { 
				if (!watching) {
					watching = true;
					watchTimer = 0f;
					StartCoroutine (ShowMessage ("Started Watching", 1));
				} else { //if you're already watching the picture, carry on with the timer
					watchTimer += Time.deltaTime;
					Debug.Log("time: " + watchTimer.ToString());
					if(watchTimer==1){
					EmoMentalCommand.EnableMentalCommandAction(EmoMentalCommand.MentalCommandActionList[0],true);
					EmoMentalCommand.StartTrainingMentalCommand(EmoMentalCommand.MentalCommandActionList[0]); // mental commandactionlist[0] is neutral, 1 is push
					}
					if (watchTimer >= 10) {
						StartCoroutine (ShowMessage ("Completed", 1));
						hit.collider.gameObject.GetComponent<MeshRenderer> ().materials [0].color = new Color(0f,1f,0f,0.1f); //adds a shade of green to the picture with 0.5 alpha
						hit.collider.gameObject.GetComponent<PictureScript>().isWatched = true;
					}
					if (EmoFacialExpression.isBlink) {
					//if (Input.GetKeyDown (KeyCode.B)) {  //TODO: switch these after testing	
						StartCoroutine (ShowMessage ("Don't Blink When Appreciating Art\nRestarting Timer", 2));
						watchTimer = 0;
					}
					if (!EmoFacialExpression.isEyesOpen) {
						//watchTimer = 0; //reset the timer if the headset isn't on or the player closes his eyes
					}
				}
			} else { //in case vision goes to something other than the painting
				watching = false;
				return;
			}
		}
	}

	IEnumerator ShowMessage (string message, float delay) {
		//blinkedText.AddComponent (typeof(GUIText));
		if (blinkedText.GetComponentInChildren<TextMesh> ()) {
			blinkedText.GetComponentInChildren<TextMesh>().text = message;
			blinkedText.GetComponentInChildren<TextMesh> ().color = Color.magenta;
			//blinkedText.GetComponentInChildren<Mes> ().fontSize = 80;
			blinkedText.GetComponentInChildren<MeshRenderer>().enabled = true;
			yield return new WaitForSeconds(delay);
			blinkedText.GetComponentInChildren<MeshRenderer>().enabled = false;
		}
	}
}
