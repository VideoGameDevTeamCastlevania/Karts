using UnityEngine;
using System.Collections;

public class MainMenuOptions : MonoBehaviour {

	private GameObject options_menu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnLevelWasLoaded(int scene)
	{
		if (scene == 1) {
			options_menu = GameObject.FindWithTag ("OptionsPanel");
		}
	}

	public void load_options ()
	{
		options_menu.SetActive (true);
	}

	public void load_menu (string menu) {
		Application.LoadLevel (menu);
	}

	public void quit () {
		Application.Quit ();
	}
}
