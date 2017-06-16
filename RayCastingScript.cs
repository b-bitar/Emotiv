using UnityEngine;
using System.Collections;

public class RayCastingScript : MonoBehaviour {

	private Vector3 cameraLocation;
	private Vector3 cameraDirection;
	public float lineOfSight = 10f;
	public static bool lookingAtPushableObject = false;

	public GameObject blinkedText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		cameraLocation = GetComponentInChildren<Camera> ().transform.position;
		cameraDirection = GetComponentInChildren<Camera> ().transform.TransformDirection (Vector3.forward);
		Ray visionRay = new Ray (cameraLocation, cameraDirection);

		Debug.DrawRay (cameraLocation, cameraDirection * 15);

		if (Physics.Raycast (visionRay, out hit, lineOfSight)) {
			switch (hit.collider.tag) {
			case "LookAtTarget":
				completeTarget (hit);
				break;
			case "HappyTarget"://Debug.Log ("smile extent is: " + EmoFacialExpression.smileExtent);
				if (EmoFacialExpression.smileExtent >= 0.8F) {
					completeTarget (hit);
				}
				break;
			case "SadTarget":
				//Debug.Log ("smile extent is: " + EmoFacialExpression.smileExtent);
				if (EmoFacialExpression.smileExtent >= 0.4F) {
					StartCoroutine (ShowMessage ("Psychopathic signs: " + Mathf.Round (EmoFacialExpression.smileExtent * 100).ToString () + "%", 2));
				} else if (EmoFacialExpression.smileExtent < 0.1F) {
					completeTarget (hit);
				}
				break;
			case "RaiseBrowTarget": 
				if (EmoFacialExpression.eyebrowExtent > 0.9f) {
					completeTarget (hit);
				}
				break;
			case "WinkTarget":
				if (EmoFacialExpression.isLeftWink || EmoFacialExpression.isRightWink) {
					completeTarget (hit);
				}
				break;
			case "ClenchTarget":
				if (EmoFacialExpression.clenchExtent > 0.5f) {
					completeTarget (hit);
				}
				break;
			case "Pushable":
				lookingAtPushableObject = true;
				break;
			default:
				//lookingAtPushableObject = false;
				return;
			}
		}
		if (EmoMentalCommand.trainingComplete) {
			EmoMentalCommand.trainingComplete = false;
			StartCoroutine (ShowMessage ("Training Complete", 2));
		}
	}

	IEnumerator ShowMessage (string message, float delay) {
		
		if (blinkedText.GetComponentInChildren<TextMesh> ()) {
			blinkedText.GetComponentInChildren<TextMesh>().text = message;
			blinkedText.GetComponentInChildren<TextMesh> ().color = Color.magenta;
			//blinkedText.GetComponentInChildren<Mes> ().fontSize = 80;
			blinkedText.GetComponentInChildren<MeshRenderer>().enabled = true;
			yield return new WaitForSeconds(delay);
			blinkedText.GetComponentInChildren<MeshRenderer>().enabled = false;
		}
	}

	void completeTarget(RaycastHit hit){
		if (hit.collider.tag == "LookAtTarget") {
			hit.collider.gameObject.GetComponent<MeshRenderer> ().materials [0].color = Color.green;
			return;
		}
		hit.collider.gameObject.GetComponent<MeshRenderer> ().materials [0].color = new Color (0f, 1f, 0f, 0.1f); //adds a shade of green to the picture with 0.5 alpha
		if (hit.collider.gameObject.GetComponent<PictureScript> ()) {
			hit.collider.gameObject.GetComponent<PictureScript> ().isWatched = true;
		}
	}

}
