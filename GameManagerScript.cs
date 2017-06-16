using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	public GameObject player;
	public GameObject spawnPoint;
	public GameObject pushTrainingCube;
	public GameObject pushTrainingZone;
	public static int currentRoom = 5;

	private Vector3[] spawnPointPositions;
	private bool trainingInProgress;
	public static bool trainingComplete = false;

	void Awake() {
		trainingInProgress = false;
		spawnPointPositions = new Vector3[8];
		spawnPointPositions [0] = new Vector3 (0f, 1.5f, 0f);
		spawnPointPositions [1] = new Vector3 (40f, 1.5f, 0f);
		spawnPointPositions [2] = new Vector3 (40f, 1.5f, 40f);
		spawnPointPositions [3] = new Vector3 (0f, 1.5f, 40f);
		spawnPointPositions [4] = new Vector3 (0f, 19f, 0f);
		spawnPointPositions [5] = new Vector3 (40f, 19f, 0f);
		spawnPointPositions [6] = new Vector3 (40f, 19f, 40f);
		spawnPointPositions [7] = new Vector3 (0f, 19f, 40f);

	}

	// Use this for initialization
	void Start () {
		//currentRoom = 0;
		player.transform.position = spawnPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//TODO: if easy mode, else do nothing
		if (currentRoom > 0) {
			spawnPoint.transform.position = spawnPointPositions [currentRoom - 1]; 
		} else {
			spawnPoint.transform.position = spawnPointPositions [0]; 
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			//EmoMentalCommand.EnableMentalCommandAction(EdkDll.IEE_MentalCommandAction_t.MC_NEUTRAL,true); //neutral doesnt need enabling
			EmoMentalCommand.StartTrainingMentalCommand(EdkDll.IEE_MentalCommandAction_t.MC_NEUTRAL); // training the neutral command
			Debug.Log("training neutral has started");
			EmoMentalCommand.trainingType = 0; //to signify that it is neutral
		}
		if (Input.GetKeyDown (KeyCode.T)) { //TODO and we are in room 4
			if (!trainingInProgress) {
				onTPressed ();
			}
		}

	}

	public void onTPressed() {
		//to ensure that the player has reached this room
		//if (currentRoom != 5) {
		//	return;
		//}
		//this slowed the code even more^

		//StartTrainingCognitiv
		EmoMentalCommand.EnableMentalCommandAction(EdkDll.IEE_MentalCommandAction_t.MC_PUSH,true);  
		EmoMentalCommand.StartTrainingMentalCommand(EdkDll.IEE_MentalCommandAction_t.MC_PUSH); // training the push command
		Debug.Log("training push has started");
		UnpushableCubeScript.moveStarted = true ;
		EmoMentalCommand.trainingType = 1;

	}

	//public static void onTrainingCompleted(){
	//	trainingComplete = true;
	//}
}
