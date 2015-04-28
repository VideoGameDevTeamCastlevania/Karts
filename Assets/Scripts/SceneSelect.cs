using UnityEngine;
using System.Collections;

public class SceneSelect : MonoBehaviour {

    public Texture2D boxbg;
	public GameObject options_menu;

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
			if (!showMenu) {
				showMenu = true;
				Time.timeScale = 0.0F;
			}
			else {
				showMenu = false;
				Time.timeScale = 1.0F;
			}
		}
	}

	// Use this for initialization
	void OnGUI () 
    {   
		if (showMenu) {
			GUI.BeginGroup (new Rect (Screen.width / 2f - 50f, Screen.height / 2f - 50f, Screen.width, Screen.height));
			GUI.Box (new Rect (0, 0, 160, 200), boxbg);
			if (GUI.Button (new Rect (10, 10, 125, 30), "Resume")) {
				Time.timeScale = 1.0F;
				showMenu = false;
			}
			if (GUI.Button (new Rect (10, 50, 125, 30), options_label)) {
				options_menu.SetActive(true);
				showMenu = false;
			}
			if (GUI.Button (new Rect (10, 90, 125, 30), restart_label)) {
				Time.timeScale = 1.0F;
				showMenu = false;
				Application.LoadLevel (Application.loadedLevelName);
			}
			if (GUI.Button (new Rect (10, 130, 125, 30), "Quit")) {
				Time.timeScale = 1.0F;
				showMenu = false;
				Application.LoadLevel("TitleScreen");
			}
			GUI.EndGroup ();
		} 
    }
}
