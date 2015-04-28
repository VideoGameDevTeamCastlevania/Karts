using UnityEngine;
using System.Collections;

// This script handles character and map selection

public class CharMapSpawnThing : MonoBehaviour {
	private static string charSelection;
	private static int mapSelectNumber;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}

	// Update is called once per frame
	void Update () {
	}

	// This will check which scene was loaded. I could just do if(index >= 7) but scene selection may move.
	void OnLevelWasLoaded(int index) {
		if (index == 7) { // 7 is  Desert Track
			spawnThings(charSelection);
		}
		if (index == 8) { // 8 is  Mountain Track
			spawnThings(charSelection);
		}
		if (index == 9) { // 9 is Rolling Hills 1
			spawnThings(charSelection);
		}
		if (index == 10) { // 10 is Rolling Hills 2
			spawnThings(charSelection);
		}
	}

	// This function is to set the map from the Map Selection screen.
	public void setMap(int mapSelect) {
		mapSelectNumber = mapSelect;
	}

	// This function is for the Confirm button on the slection screen, which then actually starts the play mode.
	public void confirm() {
		if (mapSelectNumber > 0) {
			Application.LoadLevel (mapSelectNumber);
		}
	}

	// This function sets the Character ID from each button from the Character Select screen.
	public void setChar (string selectChar) {;
		charSelection = selectChar;
		Application.LoadLevel("MapSelect");
	}

	// This function spawns the player and AI in whatever map they chose
	public void spawnThings(string character) {
		GameObject playerSpawn = GameObject.FindGameObjectWithTag ("PlayerSpawn");
		if (!playerSpawn) {
			print("No player spawn found"); // Error Checking. Had issue where scene would try to find player before scene was fully loaded.
		}
		GameObject[] AISpawn = GameObject.FindGameObjectsWithTag ("AISpawn");
		if (AISpawn.Length == 0) {
			print ("No AI spawn found"); // More error checking.
		}
		GameObject player;
		GameObject AI1;
		GameObject AI2;
		if (character == "Girl") {
			player = Instantiate (Resources.Load("GirlScout"), playerSpawn.transform.position, playerSpawn.transform.rotation) as GameObject;
			AI1 = Instantiate(Resources.Load("DogAI"), AISpawn[0].transform.position, AISpawn[0].transform.rotation) as GameObject;
			AI1.tag = "AI";
			AI2 = Instantiate(Resources.Load("MarsianAI"), AISpawn[1].transform.position, AISpawn[1].transform.rotation) as GameObject;
			AI2.tag = "AI";
		}
		if (character == "Dog") {
			player = Instantiate (Resources.Load("Dog"), playerSpawn.transform.position, playerSpawn.transform.rotation) as GameObject;
			AI1 = Instantiate(Resources.Load("GirlScoutAI"), AISpawn[0].transform.position, AISpawn[0].transform.rotation) as GameObject;
			AI1.tag = "AI";
			AI2 = Instantiate(Resources.Load("MarsianAI"), AISpawn[1].transform.position, AISpawn[1].transform.rotation) as GameObject;
			AI2.tag = "AI";
		}
		if (character == "Marsian") {
			player = Instantiate (Resources.Load ("Marsian"), playerSpawn.transform.position, playerSpawn.transform.rotation)  as GameObject;
			AI1 = Instantiate (Resources.Load ("GirlScoutAI"), AISpawn [0].transform.position, AISpawn [0].transform.rotation) as GameObject;
			AI1.tag = "AI";
			AI2 = Instantiate (Resources.Load ("DogAI"), AISpawn [1].transform.position, AISpawn [1].transform.rotation) as GameObject;
			AI2.tag = "AI";
		}
	}
}
