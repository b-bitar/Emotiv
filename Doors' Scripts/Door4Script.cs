using UnityEngine;
using System.Collections;

public class Door4Script : Door {

	// Use this for initialization
	void Start () {
		originalPosition = new GameObject ();
		finalPosition = new GameObject ();
		originalPosition.transform.position = gameObject.transform.position;
		finalPosition.transform.position = gameObject.transform.position + new Vector3 (0f, 4.5f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isOpen) {
			if (EmoMentalCommand.trainingComplete && EmoMentalCommand.trainingType ==0) {
				isOpen = true;
				openDoor ();
			}
		}
	}
}
