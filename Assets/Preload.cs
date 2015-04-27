using UnityEngine;
using System.Collections;

public class Preload : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.isPlaying) {
			Application.LoadLevel("TitleScreen");
		}
	}
}
