using UnityEngine;
using System.Collections;

public class SceneSelect : MonoBehaviour {

    public Texture2D boxbg;

    private string main_menu_label = "Main Menu";
    private string options_label = "Options";
	private string restart_label = "Restart";

    private bool showMenu;

    void Start()
    {
        showMenu = false;
    }

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!showMenu)
				showMenu = true;
			else
				showMenu = false;
		}
	}

	// Use this for initialization
	void OnGUI () 
    {   
		if (showMenu) {
			GUI.BeginGroup (new Rect (Screen.width / 2f - 50f, Screen.height / 2f - 50f, Screen.width, Screen.height));
			GUI.Box (new Rect (0, 0, 160, 200), boxbg);
			if (GUI.Button (new Rect (10, 10, 125, 30), main_menu_label)) {
				Application.LoadLevel ("TitleScreen");
			}
			if (GUI.Button (new Rect (10, 50, 125, 30), options_label)) {
//                Application.LoadLevel("Options");
			}
			if (GUI.Button (new Rect (10, 90, 125, 30), restart_label)) {
				Application.LoadLevel (Application.loadedLevelName);
			}
			if (GUI.Button (new Rect (10, 130, 125, 30), "Quit")) {
				Application.Quit ();
			}
			GUI.EndGroup ();
		} 
    }
}
