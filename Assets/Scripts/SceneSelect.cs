using UnityEngine;
using System.Collections;

public class SceneSelect : MonoBehaviour {

    public Texture2D boxbg;

    public string SceneOne;
    private string SceneOneLable = "Mountains";
    public string SceneTwo;
    private string SceneTwoLable = "Desert";
    public string SceneThree;
    private string SceneThreeLable = "Rolling Hills";

    private bool showMenu;

    void Start()
    {
        showMenu = false;
    }

	// Use this for initialization
	void OnGUI () 
    {
        if (Input.GetKey(KeyCode.M)) showMenu = true;
        else if (Input.GetKey(KeyCode.Escape)) showMenu = false;

        if (showMenu)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2f - 50f, Screen.height / 2f - 50f, Screen.width, Screen.height));
            GUI.Box(new Rect(0, 0, 160, 200), boxbg);
            if (GUI.Button(new Rect(10, 10, 125, 30), SceneOneLable))
            {
                Application.LoadLevel(SceneOne);
            }
            if (GUI.Button(new Rect(10, 50, 125, 30), SceneTwoLable))
            {
                Application.LoadLevel(SceneTwo);
            }
            if (GUI.Button(new Rect(10, 90, 125, 30), SceneThreeLable))
            {
                Application.LoadLevel(SceneThree);
            }
            if (GUI.Button(new Rect(10, 130, 125, 30), "Quit"))
            {
                Application.Quit();
            }
            GUI.EndGroup();
        }
    }
}
