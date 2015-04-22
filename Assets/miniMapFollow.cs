using UnityEngine;
using System.Collections;

public class miniMapFollow : MonoBehaviour {

    public Transform kart;
	private Transform indicator;

	// Use this for initialization
	void Start () 
    {
		indicator = transform.Find ("PlayerIndicator");	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        Transform trans = GetComponent<Transform>();
		
        trans.position = new Vector3(kart.position.x, trans.position.y, kart.position.z); 
		indicator.position = new Vector3 (kart.position.x, kart.position.y, kart.position.z);

	}
}
