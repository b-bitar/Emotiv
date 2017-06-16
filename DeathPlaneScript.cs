using UnityEngine;
using System.Collections;

public class DeathPlaneScript : MonoBehaviour {

	//This transform will hold the player's respawn point
	public Transform respawnPoint;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//This fires off when the player dies by falling off the map (ie dies at a corridor)
	void OnTriggerEnter(Collider other)
	{
		//Moves the player to the spawn point
		other.gameObject.transform.position = respawnPoint.position;
	}

}
