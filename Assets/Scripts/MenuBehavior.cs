using UnityEngine;
using System.Collections;

public class MenuBehavior : MonoBehaviour {

	public GameObject options_menu;
	public GameObject main_menu;

	void Update () {
		if (Input.GetKeyDown(KeyCode.O)) {
			options_menu.SetActive(true);
		}
	}
	
	public void load_menu (string menu) {
		Application.LoadLevel (menu);
	}
	
	public void quit () {
		Application.Quit ();
	}

	void OnLevelWasLoaded (int scene) {
		if (scene == 1) {
			main_menu.SetActive (true);
		} else {
			main_menu.SetActive (false);
		}
	}
}
