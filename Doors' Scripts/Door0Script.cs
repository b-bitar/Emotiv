	using UnityEngine;
using System.Collections;

public class Door0Script : Door {
	
	public GameObject introTexts;
	Renderer[] textsList;



	// Use this for initialization
	void Start () {
		textsList = introTexts.GetComponentsInChildren<Renderer> () as Renderer[];
		originalPosition = new GameObject ();
		finalPosition = new GameObject ();
		originalPosition.transform.position = gameObject.transform.position;
		finalPosition.transform.position = gameObject.transform.position + new Vector3 (0f, 4.5f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isOpen) {
			for (int i = 0; i < textsList.Length; i++) {
				if (textsList [i].material.color == Color.red) {
					return;
				}
			}
			isOpen = true;
			openDoor ();
		}

	}

}
