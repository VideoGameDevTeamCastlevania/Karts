﻿using UnityEngine;
using System.Collections;

public class CharMapSpawnThing : MonoBehaviour {
	private string charSelection;
	private string mapSelection;

	// Use this for initialization
	void Start () {
	
	}

	void awake() {
		DontDestroyOnLoad (transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadRollingHills1() {
	}

	public void loadRollingHills2(){
	}

	public void loadMountains(){
	}

	public void spawn(string character) {
		GameObject playerSpawn = GameObject.FindGameObjectWithTag ("PlayerSpawn");
		GameObject[] AISpawn = GameObject.FindGameObjectsWithTag ("AISpawn");
		GameObject player;
		GameObject AI1;
		GameObject AI2;
		if (character == "Girl") {
			player = Instantiate (Resources.Load("GirlScout"), playerSpawn.transform.position, playerSpawn.transform.rotation) as GameObject;
			AI1 = Instantiate(Resources.Load("Dog"), AISpawn[1].transform.position, AISpawn[1].transform.rotation) as GameObject;
			AI1.tag = "AI";
			AI2 = Instantiate(Resources.Load("Marsian"), AISpawn[2].transform.position, AISpawn[2].transform.rotation) as GameObject;
			AI2.tag = "AI";
		}
		if (character == "Dog") {
			player = Instantiate (Resources.Load("Dog"), playerSpawn.transform.position, playerSpawn.transform.rotation) as GameObject;
			AI1 = Instantiate(Resources.Load("GirlScout"), AISpawn[1].transform.position, AISpawn[1].transform.rotation) as GameObject;
			AI1.tag = "AI";
			AI2 = Instantiate(Resources.Load("Marsian"), AISpawn[2].transform.position, AISpawn[2].transform.rotation) as GameObject;
			AI2.tag = "AI";
		}
		if (character == "Marsian") {
			player = Instantiate (Resources.Load("Marsian"), playerSpawn.transform.position,  playerSpawn.transform.rotation)  as GameObject;
			AI1 = Instantiate(Resources.Load("GirlScout"), AISpawn[1].transform.position, AISpawn[1].transform.rotation) as GameObject;
			AI1.tag = "AI";
			AI2 = Instantiate(Resources.Load("Dog"), AISpawn[2].transform.position, AISpawn[2].transform.rotation) as GameObject;
			AI2.tag = "AI";
		}

	}

}
