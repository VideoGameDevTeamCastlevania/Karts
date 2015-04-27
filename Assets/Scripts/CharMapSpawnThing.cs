using UnityEngine;
using System.Collections;

public class CharMapSpawnThing : MonoBehaviour {
	private static string charSelection;
	private static int mapSelectNumber;
	private int level_index;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}

	// Update is called once per frame
	void Update () {
	}

	void OnLevelWasLoaded(int index) {
		if (index == 1) {
			spawnThings(charSelection);
		}
	}

	public void setMap(int mapSelect) {
		mapSelectNumber = mapSelect;
	}

	public void confirm(int level) {
		Application.LoadLevel (level);
	}

	public void setChar (string selectChar) {;
		charSelection = selectChar;
		Application.LoadLevel("MapSelect");
	}

	public void spawnThings(string character) {
		GameObject playerSpawn = GameObject.FindGameObjectWithTag ("PlayerSpawn");
		if (!playerSpawn) {
			print("No player spawn found");
		}
		GameObject[] AISpawn = GameObject.FindGameObjectsWithTag ("AISpawn");
		if (AISpawn.Length == 0) {
			print ("No AI spawn found");
		}
		GameObject player;
		GameObject AI1;
		GameObject AI2;
		print(playerSpawn.transform.position.x.ToString());
		if (character == "Girl") {
			player = Instantiate (Resources.Load("GirlScout"), playerSpawn.transform.position, playerSpawn.transform.rotation) as GameObject;
			AI1 = Instantiate(Resources.Load("DogAI"), AISpawn[0].transform.position, AISpawn[0].transform.rotation) as GameObject;
			AI1.tag = "AI";
			AI2 = Instantiate(Resources.Load("MarsianAI"), AISpawn[1].transform.position, AISpawn[1].transform.rotation) as GameObject;
			AI2.tag = "AI";
		}
		if (character == "Dog") {
			player = Instantiate (Resources.Load("Dog"), playerSpawn.transform.position, playerSpawn.transform.rotation) as GameObject;
			print ("SOmething should be here");
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
		} else {
			print ("Character is = " + character);
		}
	}
}
