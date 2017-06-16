using UnityEngine;
using System.Collections;

public class Doors123Script : Door {
	
	public GameObject pictures;
	PictureScript[] scripts;


	// Use this for initialization
	void Start () {
		scripts = pictures.GetComponentsInChildren<PictureScript> () as PictureScript[];
		originalPosition = new GameObject ();
		finalPosition = new GameObject ();
		originalPosition.transform.position = gameObject.transform.position;
		finalPosition.transform.position = gameObject.transform.position + new Vector3 (0f, 4.5f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isOpen) {
			for (int i = 0; i < scripts.Length; i++) {
				if (!scripts [i].isWatched) {
					return;
				}
			}
			isOpen = true;
			openDoor ();
		}
	}
}
