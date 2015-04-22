using UnityEngine;
using System.Collections;

public class miniMapFollow : MonoBehaviour {

    private GameObject kart;
	private Transform indicator;

	public float indicator_distance; //from camera

	// Use this for initialization
	void Start () 
    {
		kart = GameObject.FindWithTag ("Player");
		indicator = transform.Find ("PlayerIndicator");	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        Transform trans = GetComponent<Transform>();

		// set up camera position
        trans.position = new Vector3(kart.transform.position.x, trans.position.y, kart.transform.position.z); 
		// position indicator on minimap
		indicator.position = new Vector3 (kart.transform.position.x, trans.position.y - indicator_distance, kart.transform.position.z);

	}
}
