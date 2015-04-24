using UnityEngine;
using System.Collections;

public class MainMenuOptions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void load_menu (string menu) {
		Application.LoadLevel (menu);
	}

	public void quit () {
		Application.Quit ();
	}
}
