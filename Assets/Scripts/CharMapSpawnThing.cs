using UnityEngine;
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

}
